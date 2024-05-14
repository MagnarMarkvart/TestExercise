using App.Domain;
using App.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid,
    IdentityUserClaim<Guid>, AppUserRole, IdentityUserLogin<Guid>,
    IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
{
    public DbSet<Sector> Sectors { get; set; } = default!;
    public DbSet<UserInSector> UserInSectors { get; set; } = default!;
    public DbSet<AppRefreshToken> RefreshTokens { get; set; } = default!;
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data for Sectors
        modelBuilder.Entity<Sector>().HasData(
            // Top level sector - Manufacturing
            new Sector
            {
                Id = Guid.Parse("32fc0433-e12f-4017-9b23-927c910fb1f6"), 
                Description = "Manufacturing"
            },
            // Sectors Under Manufacturing
            new Sector
            {
                Id = Guid.Parse("0d1709d0-3df8-4462-8770-1da6694a1bc9"), 
                Description = "Construction Materials",
                SuperSectorId = Guid.Parse("32fc0433-e12f-4017-9b23-927c910fb1f6")
            },
            new Sector
            {
                Id = Guid.Parse("046157a9-a497-420c-b8f1-1234b4bea756"), 
                Description = "Food and Beverage",
                SuperSectorId = Guid.Parse("32fc0433-e12f-4017-9b23-927c910fb1f6")
            },
            // Sectors Under Food and Beverage:
            new Sector
            {
                Id = Guid.Parse("4b12e7cc-f507-475a-b198-45646f2dc4d2"), 
                Description = "Bakery &amp; confectionery products",
                SuperSectorId = Guid.Parse("046157a9-a497-420c-b8f1-1234b4bea756")
            },
            new Sector
            {
                Id = Guid.Parse("a868e04a-6d35-4eb3-8f81-539dfa5aedd8"), 
                Description = "Beverages",
                SuperSectorId = Guid.Parse("046157a9-a497-420c-b8f1-1234b4bea756")
            },
            new Sector
            {
                Id = Guid.Parse("86a44339-0353-4950-8666-f56795cd2fbe"), 
                Description = "Fish &amp; fish products",
                SuperSectorId = Guid.Parse("046157a9-a497-420c-b8f1-1234b4bea756")
            },
            new Sector
            {
                Id = Guid.Parse("13c56f1c-ccf7-40aa-9c22-67abfbf97b13"), 
                Description = "Meat &amp; meat products",
                SuperSectorId = Guid.Parse("046157a9-a497-420c-b8f1-1234b4bea756")
            },
            new Sector
            {
                Id = Guid.Parse("a9b73b0c-0ea3-4792-8522-a741463888b6"), 
                Description = "Milk &amp; dairy products",
                SuperSectorId = Guid.Parse("046157a9-a497-420c-b8f1-1234b4bea756")
            },
            new Sector
            {
                Id = Guid.Parse("853c0ac3-2dda-4081-9c49-f9125d975889"), 
                Description = "Other",
                SuperSectorId = Guid.Parse("046157a9-a497-420c-b8f1-1234b4bea756")
            },
            new Sector
            {
                Id = Guid.Parse("ae70e815-feba-43fc-a63c-ca8770c8cf34"), 
                Description = "Sweets &amp; snack food",
                SuperSectorId = Guid.Parse("046157a9-a497-420c-b8f1-1234b4bea756")
            },
            // Sectors Under Food and Beverage END
            new Sector
            {
                Id = Guid.Parse("3d78fecc-e4bc-4110-a82c-d6309a818613"), 
                Description = "Electronics and Optics",
                SuperSectorId = Guid.Parse("32fc0433-e12f-4017-9b23-927c910fb1f6")
            },
            new Sector
            {
                Id = Guid.Parse("82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c"), 
                Description = "Furniture",
                SuperSectorId = Guid.Parse("32fc0433-e12f-4017-9b23-927c910fb1f6")
            },
            // Sectors Under Furniture
            new Sector
            {
                Id = Guid.Parse("5da3c473-79b4-4bb5-adca-7fa96bd0ab53"), 
                Description = "Bathroom/sauna",
                SuperSectorId = Guid.Parse("82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c")
            },
            new Sector
            {
                Id = Guid.Parse("1246ce33-8daf-4a43-ba2f-267c8edbb743"), 
                Description = "Bedroom",
                SuperSectorId = Guid.Parse("82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c")
            },
            new Sector
            {
                Id = Guid.Parse("ee9c0b26-1e9c-4127-8e73-204eb68527c3"), 
                Description = "Children’s room",
                SuperSectorId = Guid.Parse("82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c")
            },
            new Sector
            {
                Id = Guid.Parse("77f6ce62-8a5e-44f6-a623-354393d71ea9"), 
                Description = "Kitchen",
                SuperSectorId = Guid.Parse("82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c")
            },
            new Sector
            {
                Id = Guid.Parse("e8d4e310-7b24-41f6-816c-37ce78c727c3"), 
                Description = "Living room",
                SuperSectorId = Guid.Parse("82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c")
            },
            new Sector
            {
                Id = Guid.Parse("a8e94d75-f5e9-41b1-96f1-eb56551067c3"), 
                Description = "Office",
                SuperSectorId = Guid.Parse("82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c")
            },
            new Sector
            {
                Id = Guid.Parse("ef179370-a0ba-413f-b810-d68f0a793446"), 
                Description = "Other (Furniture)",
                SuperSectorId = Guid.Parse("82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c")
            },
            new Sector
            {
                Id = Guid.Parse("880b1b11-7a44-4636-87f5-f60b4ca720da"), 
                Description = "Outdoor",
                SuperSectorId = Guid.Parse("82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c")
            },
            new Sector
            {
                Id = Guid.Parse("408cacab-4d25-4b48-b2dc-971293f78821"), 
                Description = "Project furniture",
                SuperSectorId = Guid.Parse("82b9c0c1-0f9f-4712-b1b3-135b5c3bb75c")
            },
            // Sectors Under Furniture END
            new Sector
            {
                Id = Guid.Parse("eae7965e-5ace-44d0-9b94-af116aa356eb"), 
                Description = "Machinery",
                SuperSectorId = Guid.Parse("32fc0433-e12f-4017-9b23-927c910fb1f6")
            },
            // Sectors Under Machinery
            new Sector
            {
                Id = Guid.Parse("08f64162-a545-4c92-a886-ec7df6713cb8"), 
                Description = "Machinery components",
                SuperSectorId = Guid.Parse("eae7965e-5ace-44d0-9b94-af116aa356eb")
            },
            new Sector
            {
                Id = Guid.Parse("f80ad83c-fc72-4073-bb2e-87facabbbfec"), 
                Description = "Machinery equipment/tools",
                SuperSectorId = Guid.Parse("eae7965e-5ace-44d0-9b94-af116aa356eb")
            },
            new Sector
            {
                Id = Guid.Parse("f9349e44-58aa-4976-b0d3-13d342a56733"), 
                Description = "Manufacture of machinery",
                SuperSectorId = Guid.Parse("eae7965e-5ace-44d0-9b94-af116aa356eb")
            },
            new Sector
            {
                Id = Guid.Parse("08f9c602-4a72-4b9a-9123-d05dca9570c6"), 
                Description = "Maritime",
                SuperSectorId = Guid.Parse("eae7965e-5ace-44d0-9b94-af116aa356eb")
            },
            // Sectors Under Maritime
            new Sector
            {
                Id = Guid.Parse("9732f4cb-8fb4-4e9d-9b5c-8fdb42090ea5"), 
                Description = "Aluminium and steel workboats",
                SuperSectorId = Guid.Parse("08f9c602-4a72-4b9a-9123-d05dca9570c6")
            },
            new Sector
            {
                Id = Guid.Parse("31956b83-31e5-47a8-aa27-1817c7ff57ab"), 
                Description = "Boat/Yacht building",
                SuperSectorId = Guid.Parse("08f9c602-4a72-4b9a-9123-d05dca9570c6")
            },
            new Sector
            {
                Id = Guid.Parse("4beb5253-ce43-41cc-ba03-8cbd59ae6b16"), 
                Description = "Ship repair and conversion",
                SuperSectorId = Guid.Parse("08f9c602-4a72-4b9a-9123-d05dca9570c6")
            },
            // Sectors Under Maritime END
            new Sector
            {
                Id = Guid.Parse("371a408f-7812-435f-b80a-d3ffb7e301a9"), 
                Description = "Metal structures",
                SuperSectorId = Guid.Parse("eae7965e-5ace-44d0-9b94-af116aa356eb")
            },
            new Sector
            {
                Id = Guid.Parse("1dc14ced-651b-4944-a786-a52424e15a0d"), 
                Description = "Other",
                SuperSectorId = Guid.Parse("eae7965e-5ace-44d0-9b94-af116aa356eb")
            },
            new Sector
            {
                Id = Guid.Parse("e74d5e79-ea61-45c3-a35e-069fc262afa6"), 
                Description = "Repair and maintenance service",
                SuperSectorId = Guid.Parse("eae7965e-5ace-44d0-9b94-af116aa356eb")
            },
            // Sectors Under Machinery END
            new Sector
            {
                Id = Guid.Parse("170355ac-0996-42cf-a1e5-d3992c187186"), 
                Description = "Metalworking",
                SuperSectorId = Guid.Parse("32fc0433-e12f-4017-9b23-927c910fb1f6")
            },
            // Sectors Under Metalworking
            new Sector
            {
                Id = Guid.Parse("3075fb1c-339f-4666-943c-c4d5f10812fb"), 
                Description = "Construction of metal structures",
                SuperSectorId = Guid.Parse("170355ac-0996-42cf-a1e5-d3992c187186")
            },
            new Sector
            {
                Id = Guid.Parse("33a143c7-ca06-42b1-a4b9-75bfab987860"), 
                Description = "Houses and buildings",
                SuperSectorId = Guid.Parse("170355ac-0996-42cf-a1e5-d3992c187186")
            },
            new Sector
            {
                Id = Guid.Parse("ee504569-4666-4cd9-85a0-a2c9cd0d4e83"), 
                Description = "Metal products",
                SuperSectorId = Guid.Parse("170355ac-0996-42cf-a1e5-d3992c187186")
            },
            new Sector
            {
                Id = Guid.Parse("1b5b36a4-214a-482c-b9f1-01f6c6152979"), 
                Description = "Metal works",
                SuperSectorId = Guid.Parse("170355ac-0996-42cf-a1e5-d3992c187186")
            },
            // Sectors Under Metal works
            new Sector
            {
                Id = Guid.Parse("4fc45347-e65b-44ca-b63b-90a5d29737ab"), 
                Description = "CNC-machining",
                SuperSectorId = Guid.Parse("1b5b36a4-214a-482c-b9f1-01f6c6152979")
            },
            new Sector
            {
                Id = Guid.Parse("708a8638-35c2-4b7f-80dc-cfeefeb90d08"), 
                Description = "Forgings, Fasteners",
                SuperSectorId = Guid.Parse("1b5b36a4-214a-482c-b9f1-01f6c6152979")
            },
            new Sector
            {
                Id = Guid.Parse("5b25ef14-4b9d-4706-8ed1-cc7d115984ed"), 
                Description = "Gas, Plasma, Laser cutting",
                SuperSectorId = Guid.Parse("1b5b36a4-214a-482c-b9f1-01f6c6152979")
            },
            new Sector
            {
                Id = Guid.Parse("a98d02ea-beaa-41f6-a01c-d48d27a94b2c"), 
                Description = "MIG, TIG, Aluminum welding",
                SuperSectorId = Guid.Parse("1b5b36a4-214a-482c-b9f1-01f6c6152979")
            },
            // Sectors Under Metal works END
            // Sectors Under Metalworking END
            new Sector
            {
                Id = Guid.Parse("11c4d645-baeb-4033-a965-4d39915aea87"), 
                Description = "Plastic and Rubber",
                SuperSectorId = Guid.Parse("32fc0433-e12f-4017-9b23-927c910fb1f6")
            },
            // Sectors Under Plastic and Rubber
            new Sector
            {
                Id = Guid.Parse("a158fdbc-2148-4d6f-856d-7479dd9f31fb"), 
                Description = "Packaging",
                SuperSectorId = Guid.Parse("11c4d645-baeb-4033-a965-4d39915aea87")
            },
            new Sector
            {
                Id = Guid.Parse("9f5941a1-a4ef-4e31-9114-b6333e6e8d44"), 
                Description = "Plastic goods",
                SuperSectorId = Guid.Parse("11c4d645-baeb-4033-a965-4d39915aea87")
            },
            new Sector
            {
                Id = Guid.Parse("e3a9da1a-9925-4022-ae32-af03f2f217ad"), 
                Description = "Plastic processing technology",
                SuperSectorId = Guid.Parse("11c4d645-baeb-4033-a965-4d39915aea87")
            },
            // Sectors Under Plastic processing technology
            new Sector
            {
                Id = Guid.Parse("29692620-cc6b-407c-a27d-ba918c598621"), 
                Description = "Blowing",
                SuperSectorId = Guid.Parse("e3a9da1a-9925-4022-ae32-af03f2f217ad")
            },
            new Sector
            {
                Id = Guid.Parse("e9c07801-4440-4a8b-9de7-9d3010b0d6d3"), 
                Description = "Moulding",
                SuperSectorId = Guid.Parse("e3a9da1a-9925-4022-ae32-af03f2f217ad")
            },
            new Sector
            {
                Id = Guid.Parse("fdb9e91a-9120-439f-a6a1-ff9356949420"), 
                Description = "Plastics welding and processing",
                SuperSectorId = Guid.Parse("e3a9da1a-9925-4022-ae32-af03f2f217ad")
            },
            // Sectors Under Plastic processing technology END
            new Sector
            {
                Id = Guid.Parse("19b854ef-dd95-4bca-adef-b8da58d537ed"), 
                Description = "Plastic profiles",
                SuperSectorId = Guid.Parse("11c4d645-baeb-4033-a965-4d39915aea87")
            },
            // Sectors Under Plastic and Rubber END
            new Sector
            {
                Id = Guid.Parse("4783bc42-20f7-4218-a346-cb067668cdf5"), 
                Description = "Printing",
                SuperSectorId = Guid.Parse("32fc0433-e12f-4017-9b23-927c910fb1f6")
            },
            // Sectors Under Printing
            new Sector
            {
                Id = Guid.Parse("d279196b-fb78-4f6b-927a-f10e32714fc0"), 
                Description = "Advertising",
                SuperSectorId = Guid.Parse("4783bc42-20f7-4218-a346-cb067668cdf5")
            },
            new Sector
            {
                Id = Guid.Parse("c6c2030d-27af-478b-aeb3-2d87ec872f81"), 
                Description = "Book/Periodicals printing",
                SuperSectorId = Guid.Parse("4783bc42-20f7-4218-a346-cb067668cdf5")
            },
            new Sector
            {
                Id = Guid.Parse("19f2d59d-c083-40e1-a09c-6ac38fc42145"), 
                Description = "Labelling and packaging printing",
                SuperSectorId = Guid.Parse("4783bc42-20f7-4218-a346-cb067668cdf5")
            },
            // Sectors Under Printing END
            new Sector
            {
                Id = Guid.Parse("646b7716-9852-45db-ad7c-da6e6772b3bb"), 
                Description = "Textile and Clothing",
                SuperSectorId = Guid.Parse("32fc0433-e12f-4017-9b23-927c910fb1f6")
            },
            // Sectors Under Textile and Clothing
            new Sector
            {
                Id = Guid.Parse("1b4dcf27-e168-4ead-9e9c-17f71e8b33e9"), 
                Description = "Clothing",
                SuperSectorId = Guid.Parse("646b7716-9852-45db-ad7c-da6e6772b3bb")
            },
            new Sector
            {
                Id = Guid.Parse("84fb9773-cf97-4242-97a4-b8bc4244aa02"), 
                Description = "Textile",
                SuperSectorId = Guid.Parse("646b7716-9852-45db-ad7c-da6e6772b3bb")
            },
            // Sectors Under Textile and Clothing END
            new Sector
            {
                Id = Guid.Parse("0641e2af-d4d3-49e3-b8d3-3ffc91fdbce9"), 
                Description = "Wood",
                SuperSectorId = Guid.Parse("32fc0433-e12f-4017-9b23-927c910fb1f6")
            },
            // Sectors Under Wood
            new Sector
            {
                Id = Guid.Parse("c662db43-fe38-47a9-99d5-80f02f2c6eef"), 
                Description = "Other",
                SuperSectorId = Guid.Parse("0641e2af-d4d3-49e3-b8d3-3ffc91fdbce9")
            },
            new Sector
            {
                Id = Guid.Parse("2ded67d1-457c-4bd8-8ce8-0080511144c4"), 
                Description = "Wooden building materials",
                SuperSectorId = Guid.Parse("0641e2af-d4d3-49e3-b8d3-3ffc91fdbce9")
            },
            new Sector
            {
                Id = Guid.Parse("4485157b-40c4-405d-8d98-a5367b98f74d"), 
                Description = "Wooden houses",
                SuperSectorId = Guid.Parse("0641e2af-d4d3-49e3-b8d3-3ffc91fdbce9")
            },
            // Sectors Under Wood END
            // Sectors Under Manufacturing END
            // Top level sector - Manufacturing END
            
            // Top level sector - Other
            new Sector
            {
                Id = Guid.Parse("acee74c3-cdd4-4c18-93c8-2a485d61d52e"), 
                Description = "Other"
            },
            // Sectors Under Other
            new Sector
            {
                Id = Guid.Parse("99b24a88-e6f5-43ff-9e23-b5c0e54fc49a"), 
                Description = "Creative industries",
                SuperSectorId = Guid.Parse("acee74c3-cdd4-4c18-93c8-2a485d61d52e")
            },
            new Sector
            {
                Id = Guid.Parse("3b5a581a-399b-43e5-9cd3-113b9f394c06"), 
                Description = "Energy technology",
                SuperSectorId = Guid.Parse("acee74c3-cdd4-4c18-93c8-2a485d61d52e")
            },
            new Sector
            {
                Id = Guid.Parse("817dc386-beaf-4b3b-9bb2-4b98c6a32649"), 
                Description = "Environment",
                SuperSectorId = Guid.Parse("acee74c3-cdd4-4c18-93c8-2a485d61d52e")
            },
            // Sectors Under Other END
            // Top level sector - Other END
            
            // Top level sector - Service
            new Sector
            {
                Id = Guid.Parse("a0b37c00-72bd-4522-a5d5-f0902a66d6a8"), 
                Description = "Service"
            },
            // Sectors Under Service
            new Sector
            {
                Id = Guid.Parse("4ec419ae-9eeb-49d4-9b6d-383e561e95d0"), 
                Description = "Business services",
                SuperSectorId = Guid.Parse("a0b37c00-72bd-4522-a5d5-f0902a66d6a8")
            },
            new Sector
            {
                Id = Guid.Parse("b6ff692e-c9f8-40b8-8cf6-85ae6991b387"), 
                Description = "Engineering",
                SuperSectorId = Guid.Parse("a0b37c00-72bd-4522-a5d5-f0902a66d6a8")
            },
            new Sector
            {
                Id = Guid.Parse("4ba5fd39-7a7c-48c0-a9a1-81ee64a074c3"), 
                Description = "Information Technology and Telecommunications",
                SuperSectorId = Guid.Parse("a0b37c00-72bd-4522-a5d5-f0902a66d6a8")
            },
            // Sectors Under Information Technology and Telecommunications
            new Sector
            {
                Id = Guid.Parse("37093024-3be1-4be2-8c54-9f921922d90e"), 
                Description = "Data processing, Web portals, E-marketing",
                SuperSectorId = Guid.Parse("4ba5fd39-7a7c-48c0-a9a1-81ee64a074c3")
            },
            new Sector
            {
                Id = Guid.Parse("372b1d41-619b-4a6e-9d04-f76be8cee6e3"), 
                Description = "Programming, Consultancy",
                SuperSectorId = Guid.Parse("4ba5fd39-7a7c-48c0-a9a1-81ee64a074c3")
            },
            new Sector
            {
                Id = Guid.Parse("589bf163-9180-43f0-9cf8-165c5cb2149d"), 
                Description = "Software, Hardware",
                SuperSectorId = Guid.Parse("4ba5fd39-7a7c-48c0-a9a1-81ee64a074c3")
            },
            new Sector
            {
                Id = Guid.Parse("01f0db6b-5b72-49d9-97c7-101a25e8be27"), 
                Description = "Telecommunications",
                SuperSectorId = Guid.Parse("4ba5fd39-7a7c-48c0-a9a1-81ee64a074c3")
            },
            // Sectors Under Information Technology and Telecommunications END
            new Sector
            {
                Id = Guid.Parse("3ee0c8fc-e5e9-412c-b83a-67de4101153e"), 
                Description = "Tourism",
                SuperSectorId = Guid.Parse("a0b37c00-72bd-4522-a5d5-f0902a66d6a8")
            },
            new Sector
            {
                Id = Guid.Parse("564886b1-1c65-48fb-99da-bbd047e43e77"), 
                Description = "Translation services",
                SuperSectorId = Guid.Parse("a0b37c00-72bd-4522-a5d5-f0902a66d6a8")
            },
            new Sector
            {
                Id = Guid.Parse("28caca3c-a99b-4bb9-b19b-11d6e3b07b70"), 
                Description = "Transport and Logistics",
                SuperSectorId = Guid.Parse("a0b37c00-72bd-4522-a5d5-f0902a66d6a8")
            },
            // Sectors Under Transport and Logistics
            new Sector
            {
                Id = Guid.Parse("d54417b1-dec1-4405-b14a-c1d350e1c750"), 
                Description = "Air",
                SuperSectorId = Guid.Parse("28caca3c-a99b-4bb9-b19b-11d6e3b07b70")
            },
            new Sector
            {
                Id = Guid.Parse("0c447d9b-3608-4494-86f4-496d74c95815"), 
                Description = "Rail",
                SuperSectorId = Guid.Parse("28caca3c-a99b-4bb9-b19b-11d6e3b07b70")
            },
            new Sector
            {
                Id = Guid.Parse("f7692977-8c0f-49e2-bf12-0e5cc00c555f"), 
                Description = "Road",
                SuperSectorId = Guid.Parse("28caca3c-a99b-4bb9-b19b-11d6e3b07b70")
            },
            new Sector
            {
                Id = Guid.Parse("5116d5b8-dd3c-4b6f-baf6-b8a53a3d30f3"), 
                Description = "Water",
                SuperSectorId = Guid.Parse("28caca3c-a99b-4bb9-b19b-11d6e3b07b70")
            }
            // Sectors Under Transport and Logistics END
            // Sectors Under Service END
            // Top level sector - Service END
        );
    }
}