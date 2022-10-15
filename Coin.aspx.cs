using Etherscan.Model.Dto;
using Etherscan.Repository;
using Etherscan.Repository.Interfaces;
using Etherscan.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EtherscanExample
{
    public partial class Coin : System.Web.UI.Page
    {

        private ITokenServices _tokenServices;
        private DataTable dtSource = new DataTable();

        public Coin(ITokenServices tokenServices)
        {
            _tokenServices = tokenServices;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindDataToGridView();
            }
        }


        protected void btnReset_Click(object sender, EventArgs e)
        {
            resetFields();
        }
       

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int result = 0;
            Int32.TryParse(txtTotalHolders.Text, out int _totalHolders);
            Int32.TryParse(txtTotalSupply.Text, out int _totalSupply);
            var model = new TokenDto
            {
                Name = txtName.Text,
                Contract_Address = txtContractAddress.Text,
                Symbol = txtSymbol.Text,
                Total_Holders = _totalHolders,
                Total_Supply = _totalSupply
            };
            ICollection<ValidationResult> validCheckResult = new List<ValidationResult>();

            if (Validator.TryValidateObject(model, new ValidationContext(model), validCheckResult, true) == true)
            {
                result = string.IsNullOrEmpty(txtId.Value) ? CreateToken(model) : UpdateToken(model);
            }
            else {
                StringBuilder msg = new StringBuilder();
                foreach (var item in validCheckResult)
                {
                    msg.Append($"* {item.ErrorMessage},");
                }
                MsgBox(msg.ToString());
                return;
            }

            if (result > 0) {
                BindDataToGridView();
                resetFields();
            }
        }

        protected void lEdit_Command(object sender, CommandEventArgs e)
        {


            var selectedRow = grdToken.Rows.Cast<GridViewRow>().FirstOrDefault(r => (r.FindControl("hiddenId") as HiddenField).Value == e.CommandArgument.ToString());
            txtId.Value = e.CommandArgument.ToString();
            txtName.Text = selectedRow.Cells[2].Text;
            txtSymbol.Text = selectedRow.Cells[1].Text;
            txtContractAddress.Text = selectedRow.Cells[3].Text;
            txtTotalSupply.Text = selectedRow.Cells[5].Text;
            txtTotalHolders.Text = selectedRow.Cells[4].Text;
        }

        protected void grdToken_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindDataToGridView();
            grdToken.PageIndex = e.NewPageIndex;
            grdToken.DataBind();
        }

        private void BindDataToGridView() {
            dtSource = GetTokenList();
            grdToken.DataSource = dtSource;
            grdToken.DataBind();

        }

        private DataTable GetTokenList() {
            return _tokenServices.GetList();
        }

        private int CreateToken(TokenDto model)
        {
            return _tokenServices.Create(model);
        }

        private int UpdateToken(TokenDto model)
        {
            var isValidId = Int32.TryParse(txtId.Value, out int tokenId);
            if (isValidId && tokenId != 0)
            {
                return _tokenServices.Update(tokenId, model);
            }
            return 0;
        }

        private void resetFields()
        {
            txtContractAddress.Text = txtName.Text = txtSymbol.Text = txtTotalHolders.Text = txtTotalSupply.Text = txtId.Value = string.Empty;
        }

        private void MsgBox(string sMessage)
        {
            string msg = "<script language=\"javascript\">";
            msg += "alert('" + sMessage + "');";
            msg += "</script>";
            Response.Write(msg);
        }


    }

}