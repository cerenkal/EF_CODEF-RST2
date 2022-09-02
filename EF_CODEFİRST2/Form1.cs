using EF_CODEFİRST2.Models.Context;
using EF_CODEFİRST2.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EF_CODEFİRST2.Models.Enums;

namespace EF_CODEFİRST2
{
    public partial class btnGetProducts : Form
    {
        public btnGetProducts()
        {
            InitializeComponent();
        }
        MyContext db = new MyContext();
        int secilenCatId = 0;
        int secilenProId = 0;

        private void btnGetCategories_Click(object sender, EventArgs e)
        {
            GetCategories();
        }
        private void GetCategories()
        {
            //List<Category> categories = db.Categories.Where(c=>c.Status!=DateStatus.Deleted).ToList(); //burada where koşulu baseentity de yazdığımız status ü deleted olan verileri getirme demektir. bunları gösterme diyor. bu çalıştığında veri listede gözükmüyor silindi sanıyorsun ama aslında database de duruyor. remove kullanmadın göremezsen panikleme
            List<Category> categories = db.Categories.ToList(); //bu listelemeyele bütün verileri gösteririz yani status ü inserted, modified veya deleted olsun hepsini çeker.
            dataGridView1.DataSource = categories;
            dataGridView1.Columns[2].Visible = false;
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            Category ca = new Category()
            {
                CategoryName = txtCategoryName.Text,
                Description = txtCategoryDesc.Text
            };

            db.Categories.Add(ca);
            db.SaveChanges();
            GetCategories();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtCategoryDesc.Text = "";
            txtCategoryName.Text = "";
            secilenCatId = (int)(dataGridView1.CurrentRow.Cells[2].Value);
            txtCategoryName.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtCategoryDesc.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            if (secilenCatId != 0)
            {
                Category category = db.Categories.Find(secilenCatId);
                category.CategoryName = txtCategoryName.Text;
                category.Description = txtCategoryDesc.Text;
                category.ModifiedDate = DateTime.Now;
                category.Status = DateStatus.Updated;
                db.SaveChanges();
                GetCategories();
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            Category category = db.Categories.Find(secilenCatId);
            if (category != null)
            {
                category.Status = DateStatus.Deleted;
                category.DeleteDate = DateTime.Now;
                db.SaveChanges();
                GetCategories();
            }
        }

        private void btnGetProduct_Click(object sender, EventArgs e)
        {
            GetProduct();
        }
        private void GetProduct()
        {

            List<Product> products = db.Products.ToList();
            dataGridView2.DataSource = products;
            dataGridView2.Columns[2].Visible = false;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            Product pr = new Product()
            {
                ProductName = txtProductName.Text,
                UnitPrice = Convert.ToDecimal(txtProductPrice.Text)
            };

            db.Products.Add(pr);
            db.SaveChanges();
            GetProduct();
        }
        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtProductName.Text = "";
            txtProductPrice.Text = "";
            secilenProId = (int)(dataGridView2.CurrentRow.Cells[2].Value);
            txtProductName.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txtProductPrice.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (secilenProId != 0)
            {
                Product product = db.Products.Find(secilenProId);
                product.ProductName = txtProductName.Text;
                product.UnitPrice = Convert.ToDecimal(txtProductPrice.Text);
                product.ModifiedDate = DateTime.Now;
                product.Status = DateStatus.Updated;
                db.SaveChanges();
                GetProduct();
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            Product product = db.Products.Find(secilenProId);
            if (product != null)
            {
                product.Status = DateStatus.Deleted;
                product.DeleteDate = DateTime.Now;
                db.SaveChanges();
                GetProduct();
            }
        }
    }


}

