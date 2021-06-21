using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BespokedBikesTimHawkins.Database.Models;
using BespokedBikesTimHawkins.Database.Repositories;
using BespokedBikesTimHawkins.Handlers;

namespace BespokedBikesTimHawkins.UI
{
    public partial class BeSpokedBikesForm : Form
    {
        private readonly ISalespersonHandler salespersonHandler;
        private readonly IProductHandler productHandler;
        private readonly ICustomerHandler customerHandler;
        private readonly ISaleHandler saleHandler;
        private readonly BeSpokedDbContext context;

        //Maybe clean this up with dependency injection?
        public BeSpokedBikesForm()
        {
            InitializeComponent();

            // Instantiate context and repositories
            this.context = new BeSpokedDbContext();
            var salespersonRepo = new SalespersonRepository(context);
            var productRepo = new ProductRepository(context);
            var customerRepo = new CustomerRepository(context);
            var saleRepo = new SaleRepository(context);

            // Instantiate handlers
            this.salespersonHandler = new SalespersonHandler(salespersonRepo);
            this.productHandler = new ProductHandler(productRepo);
            this.customerHandler = new CustomerHandler(customerRepo);
            this.saleHandler = new SaleHandler(saleRepo);
        }

        #region Couldn't get rid of these or it would mess up the whole UI ¯\_(ツ)_/¯
        private void salesTabPage_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void salespersonsFirstNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void salespersonsLastNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void salespersonsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

        #region Salesperson tab
        private async void salespersonsUpdateButton_Click(object sender, EventArgs e)
        {
            var salesperson = new Salesperson
            {
                SalespersonId = Guid.Parse(this.salespersonsIdValueLabel.Text),
                FirstName = this.salespersonsFirstNameTextBox.Text,
                LastName = this.salespersonsLastNameTextBox.Text,
                Address = this.salespersonsAddressTextBox.Text,
                Phone = this.salespersonsPhoneTextBox.Text,
                StartDate = this.salespersonsStartDateDateTimePicker.Value,
                TerminationDate = salespersonsCheckBox.Checked ? (DateTime?)null : this.salespersonsTerminationDateDateTimePicker.Value,
                Manager = this.salespersonsManagerTextBox.Text
            };

            var successfulUpdate = await this.salespersonHandler.UpdateSalespersonAsync(salesperson);
            if (successfulUpdate)
            {
                MessageBox.Show("Salesperson successfully updated!");
            }
            else
            {
                MessageBox.Show("Error updating Salesperson.");
            }
            salespersonsDataGridView.DataSource = this.context.Salespersons.ToList();
        }

        private void salespersonsDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = salespersonsDataGridView.Rows[e.RowIndex];
                this.salespersonsIdValueLabel.Text = row.Cells[0].Value.ToString();
                this.salespersonsFirstNameTextBox.Text = row.Cells[1].Value.ToString();
                this.salespersonsLastNameTextBox.Text = row.Cells[2].Value.ToString();
                this.salespersonsAddressTextBox.Text = row.Cells[3].Value.ToString();
                this.salespersonsPhoneTextBox.Text = row.Cells[4].Value.ToString();
                this.salespersonsStartDateDateTimePicker.Value = Convert.ToDateTime(row.Cells[5].Value.ToString());
                this.salespersonsTerminationDateDateTimePicker.Value = !String.IsNullOrEmpty(row.Cells[6].Value.ToString())
                    ? Convert.ToDateTime(row.Cells[6].Value.ToString())
                    : this.salespersonsTerminationDateDateTimePicker.Value;
                this.salespersonsManagerTextBox.Text = row.Cells[7].Value.ToString();
            }
        }
        #endregion

        #region Products tab
        private async void productsUpdateButton_Click(object sender, EventArgs e)
        {
            var product = new Product
            {
                ProductId = Guid.Parse(this.productsIdValueLabel.Text),
                Name = this.productsNameTextBox.Text,
                Manufacturer = this.productsManufacturerTextBox.Text,
                Style = this.productsStyleTextBox.Text,
                PurchasePrice = Convert.ToDecimal(this.productsPurchasePriceTextBox.Text),
                SalePrice = Convert.ToDecimal(this.productsSalesPriceTextBox.Text),
                QtyOnHand = Convert.ToInt32(this.productsQtyOnHandTextBox.Text),
                CommissionPercentage = Convert.ToDecimal(this.productsCommissionPercentageTextBox.Text)
            };

            var successfulUpdate = await this.productHandler.UpdateProductAsync(product);
            if (successfulUpdate)
            {
                MessageBox.Show("Product successfully updated!");
            }
            else
            {
                MessageBox.Show("Error updating Product.");
            }
            productsDataGridView.DataSource = this.context.Products.ToList();
        }

        private void productsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = productsDataGridView.Rows[e.RowIndex];
                this.productsIdValueLabel.Text = row.Cells[0].Value.ToString();
                this.productsNameTextBox.Text = row.Cells[1].Value.ToString();
                this.productsManufacturerTextBox.Text = row.Cells[2].Value.ToString();
                this.productsStyleTextBox.Text = row.Cells[3].Value.ToString();
                this.productsPurchasePriceTextBox.Text = row.Cells[4].Value.ToString();
                this.productsSalesPriceTextBox.Text = row.Cells[5].Value.ToString();
                this.productsQtyOnHandTextBox.Text = row.Cells[6].Value.ToString();
                this.productsCommissionPercentageTextBox.Text = row.Cells[7].Value.ToString();
            }
        }
        #endregion

        #region Sales tab
        private async void salesCreateButton_Click(object sender, EventArgs e)
        {
            var sale = new Sale
            {
                SalesId = Guid.NewGuid(),
                ProductId = Guid.Parse(salesProductIdTextBox.Text),
                SalespersonId = Guid.Parse(salesSalespersonIdTextBox.Text),
                CustomerId = Guid.Parse(salesCustomerIdTextBox.Text),
                SalesDate = salesDateDateTimePicker.Value
            };

            var successfulCreation = await this.saleHandler.CreateSaleAsync(sale);
            if (successfulCreation)
            {
                MessageBox.Show("Sale successfully created!");
            }
            else
            {
                MessageBox.Show("Error creating sale.");
            }
            salesDataGridView.DataSource = this.context.Sales.ToList();
        }

        private void salesSearchbutton_Click(object sender, EventArgs e)
        {
            var startDate = salesFromDateTimePicker.Value;
            var endDate = salesToDateTimePicker.Value;
            var sales = this.saleHandler.GetSalesBetweenDates(startDate, endDate);
            salesDataGridView.DataSource = sales;
        }

        private void salesShowAllButton_Click(object sender, EventArgs e)
        {
            salesDataGridView.DataSource = this.context.Sales.ToList();
        }
        #endregion



        private void BeSpokedBikesForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'beSpokedDbDataSet3.Salesperson' table. You can move, or remove it, as needed.
            this.salespersonTableAdapter.Fill(this.beSpokedDbDataSet3.Salesperson);
            // TODO: This line of code loads data into the 'beSpokedDbDataSet2.Sales' table. You can move, or remove it, as needed.
            this.salesTableAdapter.Fill(this.beSpokedDbDataSet2.Sales);
            // TODO: This line of code loads data into the 'beSpokedDbDataSet1.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.beSpokedDbDataSet1.Customer);
            // TODO: This line of code loads data into the 'beSpokedDbDataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.beSpokedDbDataSet.Product);

        }
    }
}
