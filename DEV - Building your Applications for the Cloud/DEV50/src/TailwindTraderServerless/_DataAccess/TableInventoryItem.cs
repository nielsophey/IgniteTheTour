using Microsoft.WindowsAzure.Storage.Table;
using Model;

namespace DataAccess
{
    public class TableInventoryItem : TableEntity, IInventoryItem
    {
        [IgnoreProperty]
        public string Sku
        {
            get
            {
                return RowKey;
            }
            set
            {
                RowKey = value ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(value))
                {
                    PartitionKey = value[0].ToString();
                }
                else
                {
                    PartitionKey = string.Empty;
                }
            }
        }
        public string MachineDescription { get; set; }
        public string HumanDescription { get; set; }

        [IgnoreProperty]
        public string Description
        {
            get
            {
                return string.IsNullOrWhiteSpace(HumanDescription) ? MachineDescription : HumanDescription;
            }
        }

        public string ImageUrl { get; set; }

        public double PriceDouble { get; set; }

        [IgnoreProperty]
        public decimal Price
        {
            get
            {
                return (decimal)PriceDouble;
            }

            set
            {
                PriceDouble = (float)value;
            }
        }

        public bool ImageSet { get; set; }
        public bool DescriptionSet { get; set; }
        public bool PriceSet { get; set; }
        public bool IsActive { get; set; }
    }
}
