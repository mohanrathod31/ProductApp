using ProductApp.Data;
using ProductApp.Data.Models;
using ProductApp.Interfaces;

namespace ProductApp.Services
{
    public class ProductService : IProduct
    {
        private AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            var _product = new Product()
            {
                ProductName = product.ProductName,
                ProductCode = product.ProductCode,
                ProductYear = product.ProductYear,
                ChannelId = product.ChannelId,
                SizeScaleId = product.SizeScaleId,
                CreatedBy = product.CreatedBy,
                CreatedDate = product.CreatedDate
            };
            _context.Products.Add(_product);
            _context.SaveChanges();

            foreach (var art in product.Articles)
            {
                var article = new Article()
                {
                    ProductId = _product.ProductId,
                    ColourId = art.ColourId
                };
                _context.Articles.Add(article);
                _context.SaveChanges();
            }
        }

        public void AddColour(Colour colour)
        {
            var _colour = new Colour()
            {
                ColourId = colour.ColourId,
                ColourCode = colour.ColourCode,
                ColourName = colour.ColourName,
            };
            _context.Colours.Add(colour);
            _context.SaveChanges();
        }

        public void AddSizeScale(SizeScale sizeScale)
        {
            var _sizeScale = new SizeScale()
            {
                SizeId = sizeScale.SizeId,
                SizeName = sizeScale.SizeName,
            };
            _context.SizeScales.Add(sizeScale);
            _context.SaveChanges();
        }

        public ProductViewModel GetProductById(Guid ProductId)
        {
            var _products = _context.Products.Where(n => n.ProductId == ProductId).Select(product => new ProductViewModel()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductCode = product.ProductCode,
                SizeScaleId = product.SizeScaleId,
                CreateDate = product.CreatedDate,
                CreatedBy = product.CreatedBy,
                ChannelId = product.ChannelId,
                Articles = GetArticles(),
                Sizes = GetSizes()
            }).FirstOrDefault();

            return _products;
        }

        public List<ArticleVM> GetArticles()
        {
            List<ArticleVM> articles = new List<ArticleVM>();

            articles.Add(new ArticleVM {  ColourCode = "colourzcode1", ColourName = "1st street" , ArticleName = "ABCXYZ" });
            articles.Add(new ArticleVM {  ColourCode = "colourzcode2", ColourName = "1st street", ArticleName = "ABCXY99" });

            return articles;

        }

        public List<Size> GetSizes()
        {
            List<Size> sizes = new List<Size>();

            sizes.Add(new Size {  SizeName = "Report 1" });
            sizes.Add(new Size {  SizeName = "Report 2"});


            return sizes;

        }

    }

}

