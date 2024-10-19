namespace DeskMarket.Common
{
	public static class ValidationConstants
	{
		// Product
		public const int ProductNameMinLength = 2;
		public const int ProductNameMaxLength = 60;
		public const int ProductDescriptionMinLength = 10;
		public const int ProductDescriptionMaxLength = 250;
		public const decimal ProductPriceMinValue = 1.00m;
		public const decimal ProductPriceMaxValue = 3000.00m;
		public const int ImageUrlMaxLength = 2048;
		public const string ProductDateTimeFormat = "dd-MM-yyyy";

		// Category
		public const int CategoryNameMinLength = 3;
		public const int CategoryNameMaxLength = 20;
	}
}
