using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Controls;
using DemoMain.Models;
using System.Data;
using System.Windows;

namespace DemoMain.ViewModels
{
    class AppViewModel
    {
        // connection string
        readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\course 2\1.C#\ProjectWPF\Course-Project-WPF\DemoMain\DemoMain\CarsDB.mdf;Integrated Security=True";

        public Offer ActiveOffer { get; private set; }
        public List<Offer> CatalogOffers { get; } = new List<Offer>();

        // this method provides initial data for application
        public void PreloadOffers(Image leftBtn, Image rightBtn)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter($"select * from Offers", connection);

                DataSet set = new DataSet();

                adapter.Fill(set);

                foreach (DataRow row in set.Tables[0].Rows)
                {
                    Offer loadOffer = new Offer(
                        row.Field<string>("owner"),
                        row.Field<string>("email"),
                        row.Field<string>("phoneNumber"),
                        row.Field<float>("price")
                        )
                    {
                        Discount = row.Field<int>("discount")
                    };
                    CatalogOffers.Add(loadOffer);
                }

                ActiveOffer = CatalogOffers.FirstOrDefault();
                if (CatalogOffers.Count > 1)
                {
                    rightBtn.Visibility = Visibility.Visible;
                    leftBtn.Visibility = Visibility.Hidden;
                }
                else if (CatalogOffers.Count <= 1)
                {
                    leftBtn.Visibility = Visibility.Hidden;
                    rightBtn.Visibility = Visibility.Hidden;
                }
            }
        }

        // inserting new offer
        public void AddOffer(string address, string owner, string email, string phoneNumber, int squareFeet, float price, Label addressLabel, Label ownerLabel, Label emailLabel, Label phoneLabel, Label feetLabel, Label priceLabel, Image rightBtn, Image leftBtn, Canvas catalog, Label noOffersLabel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter("select * from Offers", connection);

                DataSet set = new DataSet();

                adapter.Fill(set);

                DataRow row = set.Tables[0].NewRow();

                Offer offer = new Offer( owner, email, phoneNumber, price);

                row[1] = offer.Owner;
                row[2] = offer.Email;
                row[3] = offer.PhoneNumber;
                row[5] = offer.Price;

                set.Tables[0].Rows.Add(row);

                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                adapter.Update(set);

                CatalogOffers.Add(offer);

                ActiveOffer = offer;

                ownerLabel.Content = ActiveOffer.Owner;
                emailLabel.Content = ActiveOffer.Email;
                phoneLabel.Content = ActiveOffer.PhoneNumber;
                priceLabel.Content = ActiveOffer.Price;
                if (CatalogOffers.Count > 1)
                {
                    rightBtn.Visibility = Visibility.Hidden;
                    leftBtn.Visibility = Visibility.Visible;
                }
                else if (CatalogOffers.Count <= 1)
                {
                    leftBtn.Visibility = Visibility.Hidden;
                    rightBtn.Visibility = Visibility.Hidden;
                }
                catalog.Visibility = Visibility.Visible;
                noOffersLabel.Visibility = Visibility.Hidden;
            }
        }
    }
}
