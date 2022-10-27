using System;
using System.Text;
using System.Web;

static class CloudbedsUris
{
    const string TemplateUrl_RequestOAuthAccess =
        "{{iwsServerUrl}}/api/v1.1/oauth?client_id={{iwsClientId}}&redirect_uri={{iwsOAuthResponseUri}}&response_type=code&" 
        + "scope=" 
        + "read:dashboard"
        + "%20read:guest"
        + "%20write:adjustment"
        + "%20write:item"
        ;

    /*
        const string TemplateUrl_RequestOAuthRefreshToken =
            "{{iwsServerUrl}}/api/v1.1/access_token?grant_type=refresh_token&client_id={{iwsClientId}}&client_secret={{iwsClientSecret}}&code={{iwsOAuthCode}}";
    */
    const string TemplateUrl_RequestOAuthRefreshToken =
        "{{iwsServerUrl}}/api/v1.1/access_token";

    const string TemplateUrl_RequestOAuthRefreshToken_PostContents =
        "grant_type=refresh_token&client_id={{iwsClientId}}&client_secret={{iwsClientSecret}}&refresh_token={{iwsOAuthRefreshToken}}";


    const string TemplateUrl_RequestOAuthAccessToken =
        "{{iwsServerUrl}}/api/v1.1/access_token";

    const string TemplateUrl_RequestOAuthAccessToken_PostContents =
       "grant_type=authorization_code&client_id={{iwsClientId}}&client_secret={{iwsClientSecret}}&redirect_uri={{iwsOAuthResponseUri}}&code={{iwsOAuthCode}}";


    const string TemplateUrl_HotelDashboard = "{{iwsServerUrl}}/api/v1.1/getDashboard";
    const string TemplateUrl_RequestAuthUserInfo = "{{iwsServerUrl}}/api/v1.1/userinfo";

    /// <summary>
    /// Get the Dashboard for the hotel
    /// </summary>
    /// <param name="cbAppConfig"></param>
    /// <returns></returns>
    internal static string UriGenerate_RequestDashboard(ICloudbedsServerInfo cbServerInfo)
    {
        var sb = new StringBuilder(TemplateUrl_HotelDashboard);

        //===================================================================
        //Perform the replacements
        //===================================================================
        sb.Replace("{{iwsServerUrl}}", cbServerInfo.ServerUrl);
        //Make sure we replaced all the tokens
        var outText = sb.ToString();
        AssertTemplateCompleted(outText);
        return outText;

    }


    /// <summary>
    /// Get the user info for the user who has authenticated us
    /// </summary>
    /// <param name="cbAppConfig"></param>
    /// <returns></returns>
    internal static string UriGenerate_RequestAuthUserInfo(ICloudbedsServerInfo cbServerInfo)
    {
        var sb = new StringBuilder(TemplateUrl_RequestAuthUserInfo);

        //===================================================================
        //Perform the replacements
        //===================================================================
        sb.Replace("{{iwsServerUrl}}", cbServerInfo.ServerUrl);
        //Make sure we replaced all the tokens
        var outText = sb.ToString();
        AssertTemplateCompleted(outText);
        return outText;

    }


    /// <summary>
    /// Called to broker an access token
    /// </summary>
    /// <param name="cbAppConfig"></param>
    /// <param name="oauthCode"></param>
    /// <returns></returns>
    public static string UriGenerate_RequestOAuthRefreshToken(CloudbedsAppConfig cbAppConfig)
    {
        var sb = new StringBuilder(TemplateUrl_RequestOAuthRefreshToken);

        //===================================================================
        //Perform the replacements
        //===================================================================
        sb.Replace("{{iwsServerUrl}}", cbAppConfig.CloudbedsServerUrl);

        //Make sure we replaced all the tokens
        var outText = sb.ToString();
        AssertTemplateCompleted(outText);
        return outText;
    }

    /// <summary>
    /// Called to broker an access token
    /// </summary>
    /// <param name="cbAppConfig"></param>
    /// <param name="oauthCode"></param>
    /// <returns></returns>
    public static string UriGenerate_RequestOAuthRefreshToken_PostContents(CloudbedsAppConfig cbAppConfig, OAuth_RefreshToken oauthRefreshToken)
    {
        var sb = new StringBuilder(TemplateUrl_RequestOAuthRefreshToken_PostContents);

        //===================================================================
        //Perform the replacements
        //===================================================================
        //        sb.Replace("{{iwsServerUrl}}", cbAppConfig.CloudbedsServerUrl);
        sb.Replace("{{iwsClientId}}", cbAppConfig.CloudbedsAppClientId);
        sb.Replace("{{iwsClientSecret}}", cbAppConfig.CloudbedsAppClientSecret);
        sb.Replace("{{iwsOAuthRefreshToken}}", oauthRefreshToken.TokenValue);

        //Make sure we replaced all the tokens
        var outText = sb.ToString();
        AssertTemplateCompleted(outText);
        return outText;
    }




    /// <summary>
    /// Called to broker an access token
    /// </summary>
    /// <param name="cbAppConfig"></param>
    /// <param name="oauthCode"></param>
    /// <returns></returns>
    public static string UriGenerate_RequestOAuthAccessToken(CloudbedsAppConfig cbAppConfig)
    {
        var sb = new StringBuilder(TemplateUrl_RequestOAuthAccessToken);

        //===================================================================
        //Perform the replacements
        //===================================================================
        sb.Replace("{{iwsServerUrl}}", cbAppConfig.CloudbedsServerUrl);

        //Make sure we replaced all the tokens
        var outText = sb.ToString();
        AssertTemplateCompleted(outText);
        return outText;
    }

    /// <summary>
    /// Called to broker an access token
    /// </summary>
    /// <param name="cbAppConfig"></param>
    /// <param name="oauthCode"></param>
    /// <returns></returns>
    public static string UriGenerate_RequestOAuthAccessToken_PostContents(CloudbedsAppConfig cbAppConfig, OAuth_BootstrapCode oAuthBootstrapCode)
    {
        var sb = new StringBuilder(TemplateUrl_RequestOAuthAccessToken_PostContents);

        //===================================================================
        //Perform the replacements
        //===================================================================
//        sb.Replace("{{iwsServerUrl}}", cbAppConfig.CloudbedsServerUrl);
        sb.Replace("{{iwsClientId}}", cbAppConfig.CloudbedsAppClientId);
        sb.Replace("{{iwsClientSecret}}", cbAppConfig.CloudbedsAppClientSecret);
        sb.Replace(
            "{{iwsOAuthResponseUri}}",
            HttpUtility.UrlEncode(cbAppConfig.CloudbedsAppOAuthRedirectUri));
        sb.Replace("{{iwsOAuthCode}}", oAuthBootstrapCode.TokenValue);

        //Make sure we replaced all the tokens
        var outText = sb.ToString();
        AssertTemplateCompleted(outText);
        return outText;
    }

    /*
    /// <summary>
    /// UNDONE: This does NOT work yet
    /// </summary>
    /// <param name="cbAppConfig"></param>
    /// <param name="oauthCode"></param>
    /// <returns></returns>
    public static string UriGenerate_RequestOAuthRefreshToken(CloudbedsAppConfig cbAppConfig, string oauthCode)
    {
        var sb = new StringBuilder(TemplateUrl_RequestOAuthRefreshToken);

        //===================================================================
        //Perform the replacements
        //===================================================================
        sb.Replace("{{iwsServerUrl}}", cbAppConfig.CloudbedsServerUrl);
        sb.Replace("{{iwsClientId}}", cbAppConfig.CloudbedsAppClientId);
        sb.Replace("{{iwsClientSecret}}", cbAppConfig.CloudbedsAppClientSecret);
        sb.Replace("{{iwsOAuthCode}}", oauthCode);

        //Make sure we replaced all the tokens
        var outText = sb.ToString();
        AssertTemplateCompleted(outText);
        return outText;
    }
    */

    /// <summary>
    /// URI to use for requesting an application key
    /// </summary>
    /// <param name="cbAppConfig"></param>
    /// <returns></returns>
    public static string UriGenerate_RequestOAuthAccess(CloudbedsAppConfig cbAppConfig)
    {
        var sb = new StringBuilder(TemplateUrl_RequestOAuthAccess);

        //===================================================================
        //Perform the replacements
        //===================================================================
        sb.Replace("{{iwsServerUrl}}", cbAppConfig.CloudbedsServerUrl);
        sb.Replace("{{iwsClientId}}", cbAppConfig.CloudbedsAppClientId);
        sb.Replace(
            "{{iwsOAuthResponseUri}}",
            HttpUtility.UrlEncode(cbAppConfig.CloudbedsAppOAuthRedirectUri));

        //Make sure we replaced all the tokens
        var outText = sb.ToString();
        AssertTemplateCompleted(outText);
        return outText;
    }


    /// <summary>
    /// Double check that we have taken care of the tokens
    /// </summary>
    /// <param name="text"></param>
    private static void AssertTemplateCompleted(string text)
    {
        if(text.Contains("{{"))
            {
            IwsDiagnostics.Assert(false, "722-204: Template still contains tokens");
        }
    }
}
