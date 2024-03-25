using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml.Linq;
using System.Globalization;

namespace ProWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

      

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textCode.Text) || string.IsNullOrEmpty(textName.Text) || string.IsNullOrEmpty(textAmount.Text) || string.IsNullOrEmpty(textPrice.Text) || string.IsNullOrEmpty(textDate.Text))
                {
                    Label_Error.Text = "Una casilla está vacía";
                    Label_Error.Visible = true;
                    return;
                }

                string code = textCode.Text;
                if(code.Length < 1 || code.Length > 16)
                {
                    Label_Error.Text = "El código debe ser un número entre 1 y 16.";
                    Label_Error.Visible = true;
                    return;
                }

                string name = textName.Text;
                if(name.Length > 32)
                {
                    Label_Error.Text = "El maximo de carácteres del nombre son 32";
                    Label_Error.Visible = true;
                    return;
                }

                if (!int.TryParse(textAmount.Text, out int amount) || amount < 0 || amount > 9999)
                {
                    Label_Error.Text = "El precio debe estar entre 0 y 9999";
                    Label_Error.Visible = true;
                    return;
                }

                if (!float.TryParse(textPrice.Text, out float price1) || price1 < 0 || price1 > 9999.99)
                {
                    Label_Error.Text = "El precio debe estar entre 0 y 9999.99";
                    Label_Error.Visible = true;
                    return;
                }
                float price = (float)Math.Round(price1, 2);

                if (!DateTime.TryParseExact(textDate.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    Label_Error.Text = "Debe seguir el formato de el formato dd/mm/aaaa hh:mm:ss";
                    Label_Error.Visible = true;
                    return;
                }


            }
            catch(Exception ex)
            {
                Console.WriteLine("Product operationhas failed.Error: { 0}", ex.Message);
            }


        }
    }
}