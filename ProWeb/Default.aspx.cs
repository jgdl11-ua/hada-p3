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
using library;

namespace ProWeb
{
    public partial class Default : System.Web.UI.Page
    {
        private bool isValid()
        {
                if (string.IsNullOrEmpty(textCode.Text) || string.IsNullOrEmpty(textName.Text) || string.IsNullOrEmpty(textAmount.Text) || string.IsNullOrEmpty(textPrice.Text) || string.IsNullOrEmpty(textDate.Text))
                {
                    Label_Error.Text = "Una casilla está vacía";
                    Label_Error.Visible = true;
                    return false;
                }

                string code = textCode.Text;
                if (code.Length < 1 || code.Length > 16)
                {
                    Label_Error.Text = "El código debe ser un número entre 1 y 16.";
                    Label_Error.Visible = true;
                    return false;
                }

                string name = textName.Text;
                if (name.Length > 32)
                {
                    Label_Error.Text = "El maximo de carácteres del nombre son 32";
                    Label_Error.Visible = true;
                    return false;
                }

                if (!int.TryParse(textAmount.Text, out int amount) || amount < 0 || amount > 9999)
                {
                    Label_Error.Text = "La cantidad debe estar entre 0 y 9999";
                    Label_Error.Visible = true;
                    return false;
                }

                if (!float.TryParse(textPrice.Text, out float price1) || price1 < 0 || price1 > 9999.99f)
                {
                    Label_Error.Text = "El precio debe estar entre 0 y 9999.99";
                    Label_Error.Visible = true;
                    return false;
                }
                

                if (!DateTime.TryParseExact(textDate.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    Label_Error.Text = "Debe seguir el formato de el formato dd/mm/aaaa hh:mm:ss";
                    Label_Error.Visible = true;
                    return false;
                }
            return true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCategory.Items.Clear();

                CADCategory cadCategory = new CADCategory();
                List<ENCategory> categories = cadCategory.ReadAll();

                foreach (ENCategory category in categories)
                {
                    ddlCategory.Items.Add(new ListItem(category.Name, category.Id.ToString()));
                }
            
            }
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isValid())
                {
                    return;
                }

                //si es correcto
                ENProduct product = new ENProduct();
                product.Code = textCode.Text;
                product.Name = textName.Text;
                product.Amount = int.Parse(textAmount.Text);
                int categoryId = int.Parse(ddlCategory.SelectedValue);
                product.Category = categoryId;
                float price = float.Parse(textPrice.Text);
                product.Price = (float)Math.Round(price, 2);
                product.CreationDate = DateTime.ParseExact(textDate.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                bool isValidSQL = product.Create();

                if (isValidSQL)
                {
                    Label_Error.Text = "Añadido con éxito";
                    Label_Error.Visible = true;
                }
                else
                {
                    Label_Error.Text = "Error en añadir";
                    Label_Error.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Product operationhas failed.Error: { 0}", ex.Message);
            }
        }
        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isValid())
                {
                    return;
                }
                //si es correcto
                ENProduct product = new ENProduct();
                product.Code = textCode.Text;
                product.Name = textName.Text;
                product.Amount = int.Parse(textAmount.Text);
                float price = float.Parse(textPrice.Text);
                product.Price = (float)Math.Round(price, 2);
                int categoryId = int.Parse(ddlCategory.SelectedValue);
                product.Category = categoryId;
                product.CreationDate = DateTime.ParseExact(textDate.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                bool isValidSQL = product.Update();

                if (isValidSQL)
                {
                    Label_Error.Text = "El producto de " + product.Name + " fue actualizado";
                    Label_Error.Visible = true;
                }
                else
                {
                    Label_Error.Text = "Error en actualizar";
                    Label_Error.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Product operationhas failed.Error: { 0}", ex.Message);
            }
        }
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isValid())
                {
                    return;
                }
                
                ENProduct product = new ENProduct();
                product.Code = textCode.Text;
                product.Name = textName.Text;
                product.Amount = int.Parse(textAmount.Text);
                float price = float.Parse(textPrice.Text);
                product.Price = (float)Math.Round(price, 2);
                int categoryId = int.Parse(ddlCategory.SelectedValue);
                product.Category = categoryId;
                product.CreationDate = DateTime.ParseExact(textDate.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                bool isValidSQL = product.Delete();

                if (isValidSQL)
                {
                    Label_Error.Text = "Producto  de " + product.Name + "eliminado";
                    Label_Error.Visible = true;
                }
                else
                {
                    Label_Error.Text = "Error al eliminar el producto.";
                    Label_Error.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }
        protected void ButtonRead_Click(object sender, EventArgs e)
        {
            try
            {
                
                ENProduct product = new ENProduct();
                product.Code = textCode.Text;

                if (product.Read())
                {
                    textName.Text = product.Name;
                    textAmount.Text = product.Amount.ToString();
                    textPrice.Text = product.Price.ToString();
                    textDate.Text = product.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");
                    ddlCategory.Text = product.Category.ToString();

                    Label_Error.Text = "Producto leído";
                    Label_Error.Visible = true;
                }
                else
                {
                    Label_Error.Text = "El código del producto no fue encontrado";
                    Label_Error.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }
        protected void ButtonReadFirst_Click(object sender, EventArgs e)
        {
            ENProduct product = new ENProduct();
            if (product.ReadFirst()) 
            {
                textCode.Text = product.Code;
                textName.Text  = product.Name;
                textAmount.Text  = product.Amount.ToString();
                ddlCategory.Text = product.Category.ToString();
                textPrice.Text = product.Price.ToString();
                textDate.Text = product.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");
            }
            else
            {
                Label_Error.Text = "No hay productos";
                Label_Error.Visible = true;
            }
        }
        protected void ButtonReadPrev_Click(object sender, EventArgs e)
        {
            try
            {

                ENProduct product = new ENProduct();
                product.Code = textCode.Text;
                product.Name = textName.Text;
                product.Amount = int.Parse(textAmount.Text);
                float price = float.Parse(textPrice.Text);
                product.Price = (float)Math.Round(price, 2);
                int categoryId = int.Parse(ddlCategory.SelectedValue);
                product.Category = categoryId;
                product.CreationDate = DateTime.ParseExact(textDate.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                if (product.ReadPrev())
                {
                    textCode.Text = product.Code;
                    textName.Text = product.Name;
                    textAmount.Text = product.Amount.ToString();
                    textPrice.Text = product.Price.ToString();
                    ddlCategory.Text = product.Category.ToString();
                    textDate.Text = product.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");
                }
                else
                {
                    Label_Error.Text = "No hay productos anteriores";
                    Label_Error.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }
        protected void ButtonReadNext_Click(object sender, EventArgs e)
        {
            try
            {

                ENProduct product = new ENProduct();
                product.Code = textCode.Text;
                /*
                product.Name = textName.Text;
                product.Amount = int.Parse(textAmount.Text);

                float price = float.Parse(textPrice.Text);
                product.Price = (float)Math.Round(price, 2);
                product.CreationDate = DateTime.ParseExact(textDate.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                */
                if (product.ReadNext())
                {
                    textCode.Text = product.Code;
                    textName.Text = product.Name;
                    textAmount.Text = product.Amount.ToString();
                    ddlCategory.Text = product.Category.ToString();
                    textPrice.Text = product.Price.ToString();
                    textDate.Text = product.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");

                }
                else
                {
                    Label_Error.Text = "No hay productos siguientes";
                    Label_Error.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
        }
    }
}