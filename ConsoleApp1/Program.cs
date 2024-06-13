// See https://aka.ms/new-console-template for more information
using ConsoleApp1.Model;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

Console.WriteLine("Hello, World!");
var setting = new ElasticsearchClientSettings(new Uri("https://localhost:9200")).CertificateFingerprint("a356d23ded33e8bbc41330304bdd29f446bdde3767d624ff8d6ba70e16e1a7f4").Authentication(new BasicAuthentication("elastic", "eqeTv1HIGUDg-*kjizdG")).DefaultIndex("product");

var client = new ElasticsearchClient(setting);


Product product = new Product()
{
    Id = 101,
    Name = "Samsung",
    Description = "Best Mobile Saumsung",
    Price = 6900000
};

var indexResponse = client.Index<Product>(product, i => i.Index("product"));
var getProduct = client.Get<Product>("product", 100);
if (getProduct.Found)
{
    Console.WriteLine($"Found Doc:Id:{getProduct.Source.Id} Name:{getProduct.Source.Name}");
}

var productList = client.Search<Product>();
foreach (var item in productList.Documents)
{
    Console.WriteLine($"ID : {item.Id} name:{item.Name} Description={item.Description} price={item.Price}");
}
var responseDelete=client.Delete<Product>(101,i=>i.Index("product"));
Console.ReadLine();