using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace UP2022Ex
{

    public partial class Agent
    {

        public SolidColorBrush ColorCell
        {
            get
            {

                switch (Sale)
                {
                    case 25:
                        return Brushes.GreenYellow;
                    default:
                        return Brushes.White;
                }

            }
        }
        public string Photo
        {
            get
            {
                if (Logo != null)
                {
                    return "..\\Resources" + Logo;
                }
                else
                {
                    return "..\\Resources\\picture.png";
                }

            }
        }

        public string TitleType
        {
            get
            {
                List<AgentType> AllAgentType = ClassFolder.BD.data.AgentType.ToList();
                return AllAgentType[AgentTypeID - 1].Title + "|" + Title;
            }
        }

        public string SaleByTheYear
        {
            get
            {
                List<ProductSale> AllProductSale = ClassFolder.BD.data.ProductSale.ToList();
                List<ProductSale> OurProductSale = AllProductSale.Where(x => x.SaleDate.Subtract(DateTime.Today).Days <= 365 && x.AgentID == ID).ToList();
                return "Продаж за год: " + OurProductSale.Count;
            }
        }

        public string PriorityAgent
        {
            get
            {
                return "Приоритет: " + Priority;
            }
        }

        public int Sale
        {
            get
            {
                List<Product> AllProduct = ClassFolder.BD.data.Product.ToList();
                List<ProductSale> AllProductSale = ClassFolder.BD.data.ProductSale.ToList();
                List<ProductSale> OurProductSale = AllProductSale.Where(x => x.AgentID == ID).ToList();
                decimal sum = 0;
                for (int i = 0; i < OurProductSale.Count; i++)
                {
                    sum += AllProduct[OurProductSale[i].ProductID - 1].MinCostForAgent;
                }

                if (sum <= 10000)
                {
                    return 0;
                }
                else if (sum > 10000 && sum <= 50000)
                {
                    return 5;
                }
                else if (sum > 50000 && sum <= 150000)
                {
                    return 10;
                }
                else if (sum > 150000 && sum <= 500000)
                {
                    return 20;
                }
                return 25;
            }
        }

        public string SaleString
        {
            get
            {
                return Sale + "%";
            }
        }
    }
}
