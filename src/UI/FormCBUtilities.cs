using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.CompilerServices;

public partial class FormCBUtilities : Form, IShowLogs
{
    /// <summary>
    /// The currently selected Auth Context
    /// </summary>
    ICloudbedsAuthSessionBase _currentAuthSession;
    ICloudbedsServerInfo _currentServerInfo;

    public FormCBUtilities()
    {
        InitializeComponent();
    }


  
    /// <summary>
    /// Called to exit the application
    /// </summary>
    private void ExitApplication()
    {

        Application.Exit();
    }


    /// <summary>
    /// Open a file in the Windows shell (e.g. open a textfile or csv file)
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private bool AttemptToShellFile(string path)
    {
        try
        {
            System.Diagnostics.Process.Start(path);
        }
        catch(Exception ex)
        {
            AppDiagnostics.Assert(false, "Failure to shell file: " + ex.Message);
            return false;
        }

        return true; //Success
    }

    /// <summary>
    /// Shows status text in the textboxes
    /// </summary>
    /// <param name="statusLog"></param>
    private void UpdateStatusText(TaskStatusLogs statusLog, bool forceUIRefresh = false)
    {
        textBoxStatus.Text = statusLog.StatusText;
        ScrollToEndOfTextbox(textBoxStatus);

        textBoxErrors.Text = statusLog.ErrorText;

        if(forceUIRefresh)
        {
            textBoxStatus.Refresh();
            textBoxErrors.Refresh();
        }
    }


    //Scroll to the end
    private static void ScrollToEndOfTextbox(TextBox textbox)
    {
        textbox.SelectionStart = textbox.Text.Length;
        textbox.ScrollToCaret();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {

        //If the user is closing the app, then save the preferences
        if (e.CloseReason == CloseReason.UserClosing)
        {
            AppPreferences_Save();
        }

        Application.Exit();
    }

    /// <summary>
    /// Load app preferences that we want to auto-load next time
    /// </summary>
    private void AppPreferences_Load()
    {
        try
        {
            AppPreferences_Load_Inner();
        }
        catch (Exception ex)
        {
            IwsDiagnostics.Assert(false, "819-1041: Error loading app prefernces, " + ex.Message);
        }
    }

    /// <summary>
    /// Load app preferences that we want to auto-load next time
    /// </summary>
    private void AppPreferences_Load_Inner()
    {
        txtPathToAppSecrets.Text = AppSettings.LoadPreference_PathAppSecretsConfig();
        txtPathToUserTokenSecrets.Text = AppSettings.LoadPreference_PathUserAccessTokens();

        //If any of these are blank then generate them
        txtPathToAppSecrets.Text = AppPreferences_GenerateDefaultIfBlank(txtPathToAppSecrets.Text, "Templates_Secrets\\Example_AppSecrets.xml");
        txtPathToUserTokenSecrets.Text = AppPreferences_GenerateDefaultIfBlank(txtPathToUserTokenSecrets.Text, "Templates_Secrets\\Example_UserTokenSecrets.xml");
    }


    /// <summary>
    /// If the proposed path is blank, then generate a path based on the applicaiton's path and the specified sub-path
    /// </summary>
    /// <param name="proposedPath"></param>
    /// <param name="subPath"></param>
    /// <returns></returns>
    private string AppPreferences_GenerateDefaultIfBlank(string proposedPath, string subPath)
    {
        if(!string.IsNullOrWhiteSpace(proposedPath))
        {
            return proposedPath;
        }

        var basePath = AppSettings.LocalFileSystemPath;
        return Path.Combine(basePath, subPath);
    }



    /// <summary>
    /// Store app preferences that we want to auto-load next time
    /// </summary>
    private void AppPreferences_Save()
    {
        try
        {
            AppPreferences_Save_Inner();
        }
        catch(Exception ex)
        {
            IwsDiagnostics.Assert(false, "819-1014: Error storing app prefernces, " + ex.Message);
        }
    }

    /// <summary>
    /// Store app preferences that we want to auto-load next time
    /// </summary>
    private void AppPreferences_Save_Inner()
    {
        AppSettings.SavePreference_PathAppSecretsConfig(txtPathToAppSecrets.Text);
        AppSettings.SavePreference_UserTokenSecretsConfig(txtPathToUserTokenSecrets.Text);
    }


    /// <summary>
    /// Updates the text that displays our authentiaiton session information
    /// </summary>
    private void UpdateUi_CurrentAuthSession()
    {
        try
        {
            UpdateUi_CurrentAuthSession_inner();
        }
        catch(Exception ex)
        {
            IwsDiagnostics.Assert(false, "220725-256: Error updating auth text, " + ex.Message);
        }
    }

    /// <summary>
    /// Updates the text that displays our authentiaiton session information
    /// </summary>
    private void UpdateUi_CurrentAuthSession_inner()
    {
        var authSession = _currentAuthSession;
        var txtBox = txtAuthSessionInfo;
        if(authSession == null)
        {
            txtBox.Text = "No auth session";
            return;
        }

        var sb = new StringBuilder();
        sb.Append(DateTime.Now.ToString());
        sb.AppendLine();
        sb.Append(authSession.DebugStatusText());

        txtBox.Text = sb.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Form1_Load(object sender, EventArgs e)
    {
        //Load the normal application preferences
        AppPreferences_Load();

        //Update the UI
        UpdateUi_CurrentAuthSession();

        //Indicate whether any DEBUG ASSERTS should be shown in the UI
        chkShowDebugAsserts.Checked = IwsDiagnostics.ShowAssertsInUI;
    }



    /// <summary>
    /// Pushes updates to the UI
    /// </summary>
    /// <param name="statusUpdate"></param>
    void IShowLogs.NewLogResultsToShow(TaskStatusLogs statusUpdate)
    {
        textBoxStatus.Text = statusUpdate.StatusText;
        textBoxErrors.Text = statusUpdate.ErrorText;
    }


    
    private void btnGenerateCBApiSecret_Click(object sender, EventArgs e)
    {
        var statusLogs = TaskStatusLogsSingleton.Singleton;

        try
        {
            CloudbedsGenerateUserOAuthAuthenticationTokens(
                txtPathToAppSecrets.Text,
                txtPathToUserTokenSecrets.Text,
                statusLogs);
        }
        catch(Exception ex)
        {
            statusLogs.AddError("2207-1116: Unexpected error: " + ex.Message);
        }

        UpdateStatusText(statusLogs, true);
        UpdateUi_CurrentAuthSession();
    }

    /// <summary>
    /// Generate the user authentication tokens
    /// </summary>
    /// <param name="statusLogs"></param>
    /// <exception cref="Exception"></exception>
    private void CloudbedsGenerateUserOAuthAuthenticationTokens(
        string filePathAppConfig,
        string filePathUserTokenSecretOutput,
        TaskStatusLogs statusLogs)
    {

        //Validate we have valid paths
        ValidateValidFilePath_AppConfigFile(filePathAppConfig, statusLogs);
        ValidateValidDirectory_AccessTokensFile(filePathUserTokenSecretOutput, statusLogs);

        statusLogs.AddStatus("Starting...");
        UpdateStatusText(statusLogs, true);
        CloudbedsAppConfig configSignInCloudbedsApp;


        //===========================================================================================
        //Get the sign in information
        //===========================================================================================
        try
        {
            //Load the config from the files
            configSignInCloudbedsApp = new CloudbedsAppConfig(filePathAppConfig);
        }
        catch (Exception exSignInConfig)
        {
            statusLogs.AddError("Error loading sign in config file. Error: " + exSignInConfig.Message);
            throw new Exception("722-1212: Error parsing sign in config, " + exSignInConfig.Message);
        }
        _currentServerInfo = configSignInCloudbedsApp;


        //===================================================================================
        //Show the UI to parse the browser response
        //===================================================================================
        var frmDialog = new FormGetOauthResponse(
            CloudbedsUris.UriGenerate_RequestOAuthAccess(configSignInCloudbedsApp));
        var dlgResponse = frmDialog.ShowDialog(this);

        if(dlgResponse != DialogResult.OK)
        {
            statusLogs.AddError("Canceled by user");
            return;
        }

        var urlResponse = frmDialog.DialogResult_UrlResponse;
        var urlResponseParsed = new UrlPartsParse(urlResponse);

        var urlResponse_accessSecretText = urlResponseParsed.GetParameterValue("code");
        if(string.IsNullOrWhiteSpace(urlResponse_accessSecretText))
        {
            statusLogs.AddError("Reponse URL does not contain access code");
            return;
        }
        var oauthBootstrapCode = new OAuth_BootstrapCode(urlResponse_accessSecretText);


        //===============================================================================
        //Attempt to generate OAUTH ACCESS/REFRESH tokens
        //===============================================================================
        statusLogs.AddStatusHeader("Turn bootstrap into access/refresh codes");
        var cbRequestAccessToken = new CloudbedsRequestOAuthAccessToken(
            configSignInCloudbedsApp,
            oauthBootstrapCode,
            statusLogs);

        try
        {
            cbRequestAccessToken.ExecuteRequest();
        }
        catch (Exception exRequestInitialToken)
        {
            statusLogs.AddError("2207-1117: Error executing initial access token request: " + exRequestInitialToken.Message);
            return;
        }
        IwsDiagnostics.Assert(cbRequestAccessToken.CommandResult_AccessToken != null, "723-003: No access token?");
        IwsDiagnostics.Assert(cbRequestAccessToken.CommandResult_RefreshToken != null, "723-004: No refresh token?");
        statusLogs.AddStatus("Success retreiving initial access/refresh token. Expire in seconds: " + cbRequestAccessToken.CommandResult_ExpiresSeconds.ToString());

        _currentAuthSession = cbRequestAccessToken.CommandResult_CloudbedsAuthSession;

        //===============================================================================
        //Store the authenticaiton tokens
        //===============================================================================
        statusLogs.AddStatus("Persist the access tokens to storage");
        var storeManager = new CloudbedsTransientSecretStorageManager(
            cbRequestAccessToken.CommandResult_CloudbedsAuthSession,
            filePathUserTokenSecretOutput);

        statusLogs.AddStatus("Access token storage successful");


        /*
                //===============================================================================
                //Create a NEW Refresh token (and throw out the previous ones)
                //===============================================================================
                statusLogs.AddStatusHeader("Create a NEW refresh token and access token (throw out old one)");
                var cbRequestNewRefreshToken = new CloudbedsRequestOAuthRefreshToken(
                    configSignInCloudbedsApp,
                    cbRequestAccessToken.CommandResult_RefreshToken,
                    statusLogs);

                cbRequestNewRefreshToken.ExecuteRequest();

                current_oAuthAccessToken = cbRequestNewRefreshToken.CommandResult_AccessToken;
                IwsDiagnostics.Assert(current_oAuthAccessToken != null, "723-001: No access token?");
                current_oAuthRefreshToken = cbRequestNewRefreshToken.CommandResult_RefreshToken;
                IwsDiagnostics.Assert(current_oAuthRefreshToken != null, "723-002: No refresh token?");

                statusLogs.AddStatus("Success renewing access/refresh tokens. Expire in seconds: " + cbRequestNewRefreshToken.CommandResult_ExpiresSeconds.ToString());
                _currentAuthSession = cbRequestNewRefreshToken.CommandResult_CloudbedsAuthSession;
        */
    }


    private void chkShowDebugAsserts_CheckedChanged(object sender, EventArgs e)
    {
        //If the UI state was changed, make user the underlying app setting gets changed
        if (chkShowDebugAsserts.Checked != IwsDiagnostics.ShowAssertsInUI)
        {
            IwsDiagnostics.ShowAssertsInUI = chkShowDebugAsserts.Checked;
        }
    }

    private void btnLoadUserTokenFromFile_Click(object sender, EventArgs e)
    {

        var statusLogs = TaskStatusLogsSingleton.Singleton;

        try
        {
            LoadUserAuthTokenFromStorage(statusLogs);
        }
        catch (Exception ex)
        {
            statusLogs.AddError("220725-803: Error loading or validating persisted token: " + ex.Message); ;
        }

        UpdateStatusText(statusLogs, true);
        UpdateUi_CurrentAuthSession();


    }

    /// <summary>
    /// Loads a token from persisted storage
    /// </summary>
    /// <param name="statusLogs"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void LoadUserAuthTokenFromStorage(TaskStatusLogs statusLogs)
    {
        statusLogs.AddStatusHeader("Load Auth Tokens from storage");
        var filePathToPersistedToken = txtPathToUserTokenSecrets.Text;
        if (!System.IO.File.Exists(filePathToPersistedToken))
        {
            statusLogs.AddError("220825-805: Auth token file does not exist: " + filePathToPersistedToken);
            throw new Exception("220825-805: Auth token file does not exist: " + filePathToPersistedToken);
        }

        var filePathToAppSecrets = txtPathToAppSecrets.Text;
        if (!System.IO.File.Exists(filePathToAppSecrets))
        {
            statusLogs.AddError("220825-814: App secrets file does not exist: " + filePathToAppSecrets);
            throw new Exception("220825-814805: App secrets file does not exist: " + filePathToAppSecrets);
        }
        //----------------------------------------------------------
        //Load the application-global configuration from storage
        //(we need to to refresh the token)
        //----------------------------------------------------------
        var appConfigAndSecrets = new CloudbedsAppConfig(filePathToAppSecrets);
        _currentServerInfo = appConfigAndSecrets;

        //----------------------------------------------------------
        //Load the authentication secrets from storage
        //----------------------------------------------------------
        CloudbedsTransientSecretStorageManager authSecretsStorageManager = 
            CloudbedsTransientSecretStorageManager.LoadAuthTokensFromFile(filePathToPersistedToken, appConfigAndSecrets, true, statusLogs);

        var authSession = authSecretsStorageManager.AuthSession;
        //Sanity test
        if (authSession == null)
        {
            statusLogs.AddError("220725-229: No auth session returned");
        }
        else
        {
            statusLogs.AddStatus("Successfully loaded auth token from storage");
        }

        //--------------------------------------------------------------------
        //Store this at the class' level, so that it can be used by other calls
        //--------------------------------------------------------------------
        _currentAuthSession = authSession;
    }


    /// <summary>
    /// Validate that the app config file exists
    /// </summary>
    /// <param name="filePathToAppSecrets"></param>
    /// <param name="statusLogs"></param>
    /// <exception cref="Exception"></exception>
    private void ValidateValidFilePath_AppConfigFile(string filePathToAppSecrets, TaskStatusLogs statusLogs)
    {
        if(File.Exists(filePathToAppSecrets))
        {
            return;
        }

        statusLogs.AddError("220725-642: App config file does not exist: " + filePathToAppSecrets);
        throw new Exception("220725-642: App config file does not exist: " + filePathToAppSecrets);
    }

    /// <summary>
    /// Validate that the directory the Access Tokens file goes into does exist
    /// </summary>
    /// <param name="filePathToAppSecrets"></param>
    /// <param name="statusLogs"></param>
    /// <exception cref="Exception"></exception>
    private void ValidateValidDirectory_AccessTokensFile(string filePathToStoreTokens, TaskStatusLogs statusLogs)
    {
        var directoryPath = Path.GetDirectoryName(filePathToStoreTokens);
        if (System.IO.Directory.Exists(directoryPath))
        {
            return;
        }

        statusLogs.AddError("220725-642: Directory to write access token file does not exist: " + directoryPath);
        throw new Exception("220725-642: Directory to write access token file does not exist: " + directoryPath);
    }

    /// <summary>
    /// Force the refersh of the user access tokens
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnForceRefreshOfUserTokens_Click(object sender, EventArgs e)
    {
        var statusLogs = TaskStatusLogsSingleton.Singleton;

        //NOTE: We are requiring these to be of the specific class types
        //      CloudbedsAuthSession_OAuth, CloudbedsAppConfig
        //Because these contain the specific information we need to REFRESH the 
        //OAuth token (this is not a generic REST API call)
        var authSession = _currentAuthSession as CloudbedsAuthSession_OAuth;
        var serverInfo =  _currentServerInfo as CloudbedsAppConfig;

        var filePathToStoreTokens =  txtPathToUserTokenSecrets.Text;
        /*
        //We must have a directory to store the secrets file in
        var directoryPath = Path.GetDirectoryName(filePathToStoreTokens);
        if(!System.IO.Directory.Exists(directoryPath))
        {
            statusLogs.AddError("Directory does not exist: " + directoryPath);
            UpdateStatusText(statusLogs);
            return;
        }
        */

        //If there is no authentication session loaded, there is nothing to do..
        if (!ValidateAuthSessionExists(serverInfo, authSession))
        {
            UpdateStatusText(statusLogs);
            return;
        }

        try
        {
            ForceRefreshOfUserTokens(
                serverInfo,
                authSession, 
                filePathToStoreTokens, 
                statusLogs);
        }
        catch (Exception ex)
        {
            statusLogs.AddError("220723-409: Error persisting token: " + ex.Message); ;
        }

        //Update the UI
        UpdateStatusText(statusLogs);
        UpdateUi_CurrentAuthSession();
    }

    /// <summary>
    /// Refresh the auth tokens, and persist the new tokens to storage
    /// </summary>
    /// <param name="appConfig"></param>
    /// <param name="authSession"></param>
    /// <param name="filePathToStoreTokens"></param>
    /// <param name="statusLogs"></param>
    /// <exception cref="Exception"></exception>
    private void ForceRefreshOfUserTokens(CloudbedsAppConfig appConfig, CloudbedsAuthSession_OAuth authSession, string filePathToStoreTokens, TaskStatusLogs statusLogs)
    {
        //We must have a destination directory to write this file into
        ValidateValidDirectory_AccessTokensFile(filePathToStoreTokens, statusLogs);

        //===============================================================================
        //Create a NEW Refresh token (and throw out the previous ones)
        //===============================================================================
        statusLogs.AddStatusHeader("Create a NEW refresh token and access token (throw out old one)");
        var cbRequestNewRefreshToken = new CloudbedsRequestOAuthRefreshToken(
            appConfig,
            authSession.OAuthRefreshToken,
            statusLogs);

        cbRequestNewRefreshToken.ExecuteRequest();

        var newAuthSession = cbRequestNewRefreshToken.CommandResult_CloudbedsAuthSession;
        if(newAuthSession == null)
        {
            statusLogs.AddError("220725-530: Unknown failure getting refreshed auth tokens");
            throw new Exception("220725-530: Unknown failure getting refreshed auth tokens");
        }

        statusLogs.AddStatus("Success renewing access/refresh tokens. Expire in seconds: " + cbRequestNewRefreshToken.CommandResult_ExpiresSeconds.ToString());
        _currentAuthSession = newAuthSession;


        statusLogs.AddStatus("Persisting new user access tokens to storage");
        var storeTokens = new CloudbedsTransientSecretStorageManager(
            newAuthSession,
            filePathToStoreTokens);

        storeTokens.PersistSecretsToStorage();
        statusLogs.AddStatus("Success storing user access tokens");
    }


    /// <summary>
    /// Save the user access tokens to persised storage
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSaveUserAuthToken_Click(object sender, EventArgs e)
    {
        var statusLogs = TaskStatusLogsSingleton.Singleton;

        var authSession = _currentAuthSession;
        var serverInfo = _currentServerInfo;

        //If there is no authenticaiton session loaded, there is nothing to do..
        if (!ValidateAuthSessionExists(serverInfo, authSession))
        {
            UpdateStatusText(statusLogs);
            return;
        }

        try
        {
            SaveUserAuthTokenToStorage(authSession, statusLogs);
        }
        catch (Exception ex)
        {
            statusLogs.AddError("220723-409: Error persisting token: " + ex.Message); ;
        }

        UpdateStatusText(statusLogs);       
    }

    /// <summary>
    /// Save the loaded user token into storage
    /// </summary>
    private void SaveUserAuthTokenToStorage(ICloudbedsAuthSessionBase authSession, TaskStatusLogs statusLogs)
    {
        statusLogs.AddStatusHeader("Persist user auth tokens to storage");

        string filePath = txtPathToUserTokenSecrets.Text;

        var secretStorageManager = new CloudbedsTransientSecretStorageManager(
            authSession,
            filePath);

        secretStorageManager.PersistSecretsToStorage();
        statusLogs.AddStatus("Success persisting user auth tokens to storage");
    }

    /// <summary>
    /// Clears out the status logs
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void blnClearLogs_Click(object sender, EventArgs e)
    {
        TaskStatusLogsSingleton.ClearAll();
        var statusLogs = TaskStatusLogsSingleton.Singleton;
        UpdateStatusText(statusLogs, true);

    }

    /// <summary>
    /// Call a REST API
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnQueryHotelDashboard_Click(object sender, EventArgs e)
    {
        var authSession = _currentAuthSession;
        var serverInfo = _currentServerInfo;
            
        //If there is no authenticaiton session, there is nothing to do..
        if (!ValidateAuthSessionExists(serverInfo, authSession))
        {
            UpdateStatusText();
            return;
        }

        //-------------------------------------------------
        //Update the auth-token UI display
        //-------------------------------------------------
        UpdateUi_CurrentAuthSession();

        var statusLogs = TaskStatusLogsSingleton.Singleton;
        try
        {
            CallRestApi_GetDashboard(serverInfo, authSession, statusLogs);
        }
        catch(Exception ex)
        {
            statusLogs.AddError("220725-355: Unexpected error" + ex.Message);
        }

        //-------------------------------------------------
        //Update status UI
        //-------------------------------------------------
        UpdateStatusText(statusLogs);
        UpdateUi_CurrentAuthSession();
    }

    /// <summary>
    /// REST API call to get the hotel's dashboard info
    /// </summary>
    /// <param name="serverInfo"></param>
    /// <param name="authSession"></param>
    /// <param name="statusLogs"></param>
    private void CallRestApi_GetDashboard(ICloudbedsServerInfo serverInfo, ICloudbedsAuthSessionBase authSession, TaskStatusLogs statusLogs)
    {
        //===============================================================================
        //Try to get the Hotel's dashboard data
        //===============================================================================
        statusLogs.AddStatusHeader("Get hotel dashboard data");
        var cbRequestDashboard = new CloudbedsRequestDashboardData(
            serverInfo,
            authSession,
            statusLogs);

        cbRequestDashboard.ExecuteRequest();
        statusLogs.AddStatus("Success getting hotel dashboard: \r\n" + cbRequestDashboard.CommandResults_SummaryText);
    }

    private void UpdateStatusText(bool forceUIRefresh = false)
    {
        UpdateStatusText(TaskStatusLogsSingleton.Singleton, forceUIRefresh);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private bool ValidateAuthSessionExists(ICloudbedsServerInfo serverInfo, ICloudbedsAuthSessionBase authInfo)
    {
        if (authInfo == null)
        {
            TaskStatusLogsSingleton.Singleton.AddError(
                "No authentication session exists. Please create one before running commands");
            return false;
        }

        if (serverInfo == null)
        {
            TaskStatusLogsSingleton.Singleton.AddError(
                "No server information has been loaded. Please create one before running commands");
            return false;
        }

        return true;
    }

    /// <summary>
    /// Query for the user's info...
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnQueryUserInfo_Click(object sender, EventArgs e)
    {
        var authSession = _currentAuthSession;
        var serverInfo = _currentServerInfo;

        //If there is no authenticaiton session, there is nothing to do..
        if (!ValidateAuthSessionExists(serverInfo, authSession))
        {
            UpdateStatusText();
            return;
        }

        //-------------------------------------------------
        //Update the auth-token UI display
        //-------------------------------------------------
        UpdateUi_CurrentAuthSession();

        var statusLogs = TaskStatusLogsSingleton.Singleton;
        try
        {
            CallRestApi_GetUserInfo(serverInfo, authSession, statusLogs);
        }
        catch (Exception ex)
        {
            statusLogs.AddError("220725-627: Unexpected error" + ex.Message);
        }

        //-------------------------------------------------
        //Update status UI
        //-------------------------------------------------
        UpdateStatusText(statusLogs);
        UpdateUi_CurrentAuthSession();

    }

    /// <summary>
    /// Query for the user's info
    /// </summary>
    /// <param name="serverInfo"></param>
    /// <param name="authSession"></param>
    /// <param name="statusLogs"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void CallRestApi_GetUserInfo(ICloudbedsServerInfo serverInfo, ICloudbedsAuthSessionBase authSession, TaskStatusLogs statusLogs)
    {
        //===============================================================================
        //Try to get the Hotel's dashboard data
        //===============================================================================
        statusLogs.AddStatusHeader("Get auth token user info");
        var cbRequest = new CloudbedsRequestAuthUserData(
            serverInfo,
            authSession,
            statusLogs);

        //Run the request
        cbRequest.ExecuteRequest();

        statusLogs.AddStatus(
            "Success getting auth-user information: \r\n" 
            + "user email : " + cbRequest.CommandResult_UserEmail 
            + "\r\n" 
            + "user id : " + cbRequest.CommandResult_UserId.ToString()
            + "\r\n");

    }
}
