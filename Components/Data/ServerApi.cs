using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace DDON_WebPage.Components.Data;

public sealed class ServerApiClient
{
    private readonly HttpClient _httpClient;
    private readonly IDbContextFactory<AppDbContext> _dbFactory;

    public ServerApiClient(
        HttpClient httpClient,
        IDbContextFactory<AppDbContext> dbFactory)
    {
        _httpClient = httpClient;
        _dbFactory = dbFactory;
    }

    public enum AccountAction : byte
    {
        Register,
        Login,
        ForgotPassword,
        ResetPassword
    }

    public sealed class ServerResponse
    {
        public string? Message { get; set; }
        public string? Error { get; set; }
        public string? Token { get; set; }
    }

    private sealed class ServerRequest
    {
        public string Action { get; set; } = string.Empty;
        public string Account { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PasswordToken { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string EmailToken { get; set; } = string.Empty;
    }

    public async Task<ServerResponse> OperationAsync(
        AccountAction accountAction,
        string account = "",
        string password = "",
        string passwordToken = "",
        string email = "",
        string emailToken = "",
        CancellationToken cancellationToken = default)
    {
        var action = accountAction switch
        {
            AccountAction.Register => "create",
            AccountAction.Login => "login",
            AccountAction.ForgotPassword => "recover",
            AccountAction.ResetPassword => "reset",
            _ => throw new ArgumentOutOfRangeException(nameof(accountAction))
        };

        var requestData = new ServerRequest
        {
            Action = action,
            Account = account,
            Password = password,
            PasswordToken = passwordToken,
            Email = email,
            EmailToken = emailToken
        };

        HttpResponseMessage response;
        
        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = null,
            PropertyNameCaseInsensitive = true
        };

        try
        {
            response = await _httpClient.PostAsJsonAsync(
                "/api/account",
                requestData,
                jsonOptions,
                cancellationToken);
        }
        catch (TaskCanceledException)
        {
            return new ServerResponse
            {
                Error = "Request timed out."
            };
        }
        catch (HttpRequestException)
        {
            return new ServerResponse
            {
                Error = "Request failed."
            };
        }

        if (!response.IsSuccessStatusCode)
        {
            return new ServerResponse
            {
                Error = $"Server returned HTTP {(int)response.StatusCode}."
            };
        }

        ServerResponse? serverResponse;

        try
        {
            serverResponse = await response.Content.ReadFromJsonAsync<ServerResponse>(
                jsonOptions,
                cancellationToken);
        }
        catch
        {
            return new ServerResponse
            {
                Error = "Invalid JSON response."
            };
        }

        if (serverResponse is null)
        {
            return new ServerResponse
            {
                Error = "Empty server response."
            };
        }

        if (!string.IsNullOrWhiteSpace(serverResponse.Token))
        {
            await using var db = await _dbFactory.CreateDbContextAsync(cancellationToken);

            var normalizedAccount = account.ToLower();

            var userExists = await db.account
                .AsNoTracking()
                .AnyAsync(u => u.NormalName == normalizedAccount, cancellationToken);

            if (!userExists)
            {
                serverResponse.Error = "Invalid user or password.";
            }
        }

        return serverResponse;
    }
}