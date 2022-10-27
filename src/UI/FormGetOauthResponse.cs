using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class FormGetOauthResponse : Form
{

    /// <summary>
    /// Dialog output value
    /// </summary>
    public string DialogResult_UrlResponse
    {
        get
        {
            return _dialogResult_urlResponse;
        }
    }
    string _dialogResult_urlResponse;


    public FormGetOauthResponse()
    {
        InitializeComponent();
    }

    public FormGetOauthResponse(string urlForOauth) : this()
    {
        textBoxAuthRequestUri.Text = urlForOauth;
    }


    private void FormGetOauthResponse_Load(object sender, EventArgs e)
    {

    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        string urlWithAuth = txtReponseUrlFromBrowser.Text.Trim();
        if(string.IsNullOrEmpty(urlWithAuth))
        {
            MessageBox.Show(
                "Reponse URL cannot be blank. \nPlease copy/paste the browser response URL"
                , "Error"
                , MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }
        //Set the output value
        _dialogResult_urlResponse = urlWithAuth;

        this.DialogResult = DialogResult.OK;
        this.Close();
    }
}
