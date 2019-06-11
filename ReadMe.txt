
Project Documantation

1. Right click project solution and choose add the new project
	1.1.Add a Class Library (.Net Core) project and name is CoreBlog.Model
	1.2.Add a Class Library (.Net Core) project and name is CoreBlog.DAL

2. Add Models, Views and Controller folder under UI layer

3. Suggest changes to Startup.cs

	3.1.
	public IConfiguration Confguration {get;}

	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	3.2. Add the following code ConfigureService

	service.AddMvc();

	3.3. Add the following code Configure method

	app.UseStaticfiles();

	app.UseStatusCodePages();

	app.UseMvc(routes=>{
		routes.MapRoute(
			name: "default",
			template: "{controller=Home}/{action=Index}/{id?}"
		);
	});


4. Rigth click the VÝews Folder then choose the add new folder

	4.1. Add the Shared Folder under the Views Folder

	4.2. Add _Layout.cshtml under the Shared Folder

5. Right click the Views Folder then choose add the new item

	5.1. Add the Razor View Imports under Views Folder

		5.1.1. Add the following code the _ViewImports.cshtml

		@using CoreBlog.UI.Models
		@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers

	5.2. Add the Razor View Start under the View Folder

		5.2.1. Add the following code under the _ViewStart.cshtml

		@{
			Layout = "~/Views/Shared/_Layout.cshtml";
		}

6. Add the Entity FOlder under the Model Layer
	
	6.1. Add entities of project like Category.cs and Blog.cs
	6.2. Add the following code into Category.cs

	public class Category
	{
		public int Id {get; set;}
		public string Name {get; set;}

		public virtual List<Blog> Blogs {get; set;}
	}

	6.3. Add the following code into Blog.cs

	public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? AddDate { get; set; }
        public bool isActive { get; set; }
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }

7. Right click on the DAL layer then choose Nuget Package Manger

	7.1. Install initial project Microsoft.EntityFrameworkCore.SqlServer

8. Right click DAL Layer and choose add new folder name is Context

	8.1. Add ProjectContext into Context Folder
	8.2. Type the following code into Project Context

	public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options):base (options)
        {

        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

	8.3. Add the following code under the Startup.cs

	var conntection = "Server=DESKTOP-TJVLSIK;Database=BlogProjectDB;Integrated Security=true;";
            services.AddDbContext<ProjectContext>
                (options => options.UseSqlServer(conntection));

9. Open the Package Manager Console

	9.1. Add the following code into Console

		9.1.1. Add-Migration InitialCreate

		9.2.1. Update-Database

10. Right click on your project then choose Open FOlder in FÝle Explorer
	
	10.1. Select project file path and so copy it
	10.2. Open any terminal in your pc
	10.4. Type the following code into your terminal (PowerShell or Cmd)

	cd project filen path => chang it your project path

	10.5. Add the following codeunder the package.json file

	"dependencies": {
		"bootstrap":"4.3.1"
	}

	10.6. Type the following code proper method (Configure) into the Statup.cs Files

	app.UseStaticFiles(new StaticFileOptions
     {
         FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")), RequestPath = "/modules"
     });

11. Right click into Controllers Folder and add a new empty contoroller name is Home

	11.1. Type the followinf code into HomeController.cs

	public IAcionResult Index()
	{
		return View();
	}

	public IActionResult List()
	{
		retun View();
	}

	public IActionResult Details()
	{
		return View();
	}






	