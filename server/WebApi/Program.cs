using BLL_Services.Services;
using DTO_Entity_Common.Classes;
using IBll.interfaces;
using IRepository.interfaces;
using Microsoft.EntityFrameworkCore;
using REPOSITORY.Entities;
using REPOSITORY.Functions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

//builder.Services.AddDbContext()
builder.Services.AddDbContext<KitchenStoreContext>(opt => opt.UseSqlServer("Data Source=DESKTOP-783IDMP\\SQLEXPRESS;Initial Catalog=KitchenStoreContext;Integrated Security=True;TrustServerCertificate=True"));


// DAL:
builder.Services.AddScoped(typeof(ICategoryReposotory<Category>), typeof(CategoryDal));
builder.Services.AddScoped(typeof(IOrderReposotory<Order>), typeof(OrderDal));
builder.Services.AddScoped(typeof(IProdForCartReposotory<ProdForCart>), typeof(ProdForCartDal));
builder.Services.AddScoped(typeof(IProdForOrderReposotory<ProdForOrder>), typeof(ProdForOrderDal));
builder.Services.AddScoped(typeof(IProductReposotory<Product>), typeof(ProductDal));
builder.Services.AddScoped(typeof(IUserRepository<User>), typeof(UserDal));


// BLL:
builder.Services.AddScoped(typeof(ICategoryBll<Category>), typeof(CategoryService));
builder.Services.AddScoped(typeof(IOrderBll<Order>), typeof(OrderService));
builder.Services.AddScoped(typeof(ICartBll<ProdForCart>), typeof(ProdForCartService));
builder.Services.AddScoped(typeof(IProdForOrderBll<ProdForOrder>), typeof(ProdForOrderService));
builder.Services.AddScoped(typeof(IProductBll<Product>), typeof(ProductService));
builder.Services.AddScoped(typeof(IUserBll<User>), typeof(UserService));

// הגדרה של מה השרת מאפשר ולמי
builder.Services.AddCors(x => x.AddPolicy("Allow All", opt => opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// איפשור בפועל 
app.UseCors("Allow All");

app.Run();
