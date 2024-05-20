using Domain.Constants.Enums;
using ForumProject.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class DataSeeder
    {
        public static void SeedTopics(this ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Topic>().HasData(
                new Topic
                {
                    Id = new Guid("33B7ED72-9434-434A-82D4-3018B018CB87"),
                    Title = "Cats",
                    Body = "vestibulum sed arcu non odio euismod lacinia at quis risus sed vulputate odio ut enim blandit volutpat maecenas volutpat blandit aliquam etiam erat velit scelerisque in dictum non consectetur a erat nam at lectus urna duis convallis convallis tellus id interdum velit laoreet id donec ultrices tincidunt arcu non sodales neque sodales ut etiam sit amet nisl purus in mollis nunc sed id semper risus in hendrerit gravida rutrum quisque non tellus orci ac auctor augue mauris augue neque gravida in fermentum et sollicitudin ac orci phasellus egestas tellus rutrum tellus pellentesque eu tincidunt tortor aliquam nulla facilisi cras fermentum odio eu feugiat pretium nibh ipsum consequat nisl vel pretium lectus quam id leo in vitae turpis massa sed elementum tempus egestas sed sed risus pretium quam vulputate dignissim suspendisse in est ante in nibh mauris cursus mattis molestie a iaculis at erat pellentesque adipiscing commodo elit at imperdiet dui accumsan sit amet nulla facilisi morbi tempus iaculis urna id volutpat lacus laoreet non curabitur gravida arcu ac tortor dignissim convallis aenean et tortor at risus viverra adipiscing at in tellus integer feugiat scelerisque varius morbi enim nunc faucibus a pellentesque sit amet porttitor eget dolor morbi non arcu risus",
                    State = State.Pending,
                    Status = true,
                    PostDate = DateTime.Now,
                    UserId = "CD04B747-A694-4431-8C8A-7CBF278A3832"
                },
                new Topic
                {
                    Id = new Guid("0257E1E3-2135-444E-8854-DBC588A7B29B"),
                    Title = "Dogs",
                    Body = "ullamcorper eget nulla facilisi etiam dignissim diam quis enim lobortis scelerisque fermentum dui faucibus in ornare quam viverra orci sagittis eu volutpat odio facilisis mauris sit amet massa vitae tortor condimentum lacinia quis vel eros donec ac odio tempor orci dapibus ultrices in iaculis nunc sed augue lacus viverra vitae",
                    State = State.Pending,
                    Status = true,
                    PostDate = DateTime.Now,
                    UserId = "CD04B747-A694-4431-8C8A-7CBF278A3832"
                },
                new Topic
                {
                    Id = new Guid("E18A5600-0D2A-4D43-B045-F7773C5C2D8D"),
                    Title = "Snakes",
                    Body = "dictum varius duis at consectetur lorem donec massa sapien faucibus et molestie ac feugiat sed lectus vestibulum mattis ullamcorper velit sed ullamcorper morbi tincidunt ornare massa eget egestas purus viverra accumsan in nisl nisi scelerisque eu ultrices vitae auctor eu augue ut lectus arcu bibendum at varius vel pharetra vel turpis nunc eget lorem dolor sed viverra ipsum nunc aliquet bibendum enim facilisis gravida neque convallis a cras semper auctor neque vitae tempus quam pellentesque nec nam aliquam sem et tortor consequat id porta nibh venenatis cras sed felis eget velit aliquet sagittis id consectetur purus ut faucibus pulvinar elementum integer enim neque volutpat ac tincidunt vitae semper quis lectus nulla at volutpat diam ut venenatis tellus in metus vulputate eu scelerisque felis imperdiet proin fermentum leo vel orci porta non pulvinar neque laoreet suspendisse interdum consectetur libero id faucibus nisl tincidunt eget nullam non nisi est sit amet facilisis magna etiam tempor orci eu lobortis elementum nibh tellus molestie nunc non blandit massa enim nec dui nunc mattis enim ut tellus elementum sagittis vitae et leo duis ut diam quam nulla porttitor massa id neque aliquam vestibulum morbi blandit cursus risus at ultrices mi tempus imperdiet nulla malesuada pellentesque elit eget gravida cum sociis natoque penatibus et magnis dis parturient montes nascetur ridiculus mus mauris vitae ultricies leo integer malesuada nunc vel risus commodo viverra maecenas accumsan lacus vel facilisis volutpat est velit egestas dui id ornare arcu odio ut sem nulla pharetra diam sit amet nisl suscipit adipiscing bibendum est ultricies integer quis auctor elit sed vulputate mi sit amet mauris commodo quis imperdiet massa tincidunt nunc pulvinar sapien et ligula ullamcorper malesuada proin libero nunc consequat interdum varius sit amet mattis vulputate enim nulla aliquet porttitor lacus luctus accumsan tortor posuere ac ut consequat semper viverra nam libero justo laoreet sit amet cursus sit amet dictum sit amet justo donec enim diam vulputate ut pharetra sit amet aliquam id diam maecenas ultricies mi eget mauris pharetra et ultrices neque ornare aenean euismod elementum nisi quis eleifend quam adipiscing vitae proin sagittis nisl rhoncus mattis rhoncus urna neque viverra justo nec ultrices dui sapien eget mi proin sed libero enim sed faucibus turpis in eu mi bibendum neque egestas congue quisque egestas diam in arcu cursus euismod quis viverra nibh cras pulvinar mattis nunc sed blandit libero volutpat sed cras ornare arcu dui vivamus arcu felis bibendum ut tristique et egestas quis ipsum suspendisse ultrices gravida dictum fusce ut placerat orci nulla pellentesque dignissim enim sit amet venenatis urna cursus eget nunc scelerisque viverra mauris in aliquam sem fringilla ut morbi tincidunt augue interdum velit euismod in pellentesque massa placerat duis ultricies lacus sed turpis tincidunt id aliquet risus feugiat in ante metus dictum at tempor commodo ullamcorper a lacus vestibulum sed arcu non odio euismod lacinia at quis risus sed vulputate odio ut enim blandit volutpat maecenas volutpat blandit aliquam etiam erat velit scelerisque in dictum non consectetur a erat nam at lectus urna duis convallis convallis",
                    State = State.Pending,
                    Status = true,
                    PostDate = DateTime.Now,
                    UserId = "230669E4-C593-4084-BACC-E5A1AD1AD494"
                },
                new Topic
                {
                    Id = new Guid("5B365AD2-0264-46B2-86A8-C9C426EE88DD"),
                    Title = "Hamsters",
                    Body = "elementum tempus egestas sed sed risus pretium quam vulputate dignissim suspendisse in est ante in nibh mauris cursus mattis molestie a iaculis at erat pellentesque adipiscing commodo elit at imperdiet dui accumsan sit amet nulla facilisi morbi tempus iaculis urna id volutpat lacus laoreet non curabitur gravida arcu ac tortor dignissim convallis aenean et tortor at risus viverra adipiscing at in tellus integer feugiat scelerisque varius morbi enim nunc faucibus a pellentesque sit amet porttitor eget dolor morbi non arcu risus quis varius quam quisque id diam vel quam elementum pulvinar etiam non quam lacus suspendisse faucibus interdum posuere lorem ipsum dolor sit amet consectetur adipiscing elit duis tristique sollicitudin nibh sit amet commodo nulla facilisi nullam vehicula ipsum a arcu cursus vitae congue mauris",
                    State = State.Pending,
                    Status = true,
                    PostDate = DateTime.Now,
                    UserId = "1DF10D85-D5F8-4E4E-8892-92B740BF2F4F"
                }
                );
        }
        public static void SeedComments(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = new Guid("3DE83FE1-7390-4CDF-84EF-C403AC9CCE6C"),
                    Body = "lorem donec massa sapien faucibus et molestie ac feugiat sed lectus vestibulum mattis ullamcorper velit sed ullamcorper morbi tincidunt ornare massa eget egestas purus viverra",
                    PostDate = DateTime.Now,
                    UserId = "CD04B747-A694-4431-8C8A-7CBF278A3832",
                    TopicId = new Guid("33B7ED72-9434-434A-82D4-3018B018CB87")
                },
                new Comment
                {
                    Id = new Guid("B53A2B67-C7C7-4937-B2EE-275D66DD803E"),
                    Body = "imperdiet sed euismod nisi porta lorem mollis aliquam ut porttitor leo a diam sollicitudin tempor id eu nisl nunc mi ipsum faucibus vitae aliquet nec",
                    PostDate = DateTime.Now,
                    UserId = "230669E4-C593-4084-BACC-E5A1AD1AD494",
                    TopicId = new Guid("33B7ED72-9434-434A-82D4-3018B018CB87")
                },
                new Comment
                {
                    Id = new Guid("B7D286FE-6AC7-48ED-A29C-DFC475CEA0BB"),
                    Body = "egestas erat imperdiet sed euismod nisi porta lorem mollis aliquam ut porttitor leo a diam sollicitudin tempor id eu nisl nunc mi ipsum faucibus vitae",
                    PostDate = DateTime.Now,
                    UserId = "CD04B747-A694-4431-8C8A-7CBF278A3832",
                    TopicId = new Guid("0257E1E3-2135-444E-8854-DBC588A7B29B")
                },
                new Comment
                {
                    Id = new Guid("FA088C36-D4F7-4DCA-82D1-51C18C830C31"),
                    Body = "ac tincidunt vitae semper quis lectus nulla at volutpat diam ut venenatis tellus in metus vulputate",
                    PostDate = DateTime.Now,
                    UserId = "230669E4-C593-4084-BACC-E5A1AD1AD494",
                    TopicId = new Guid("E18A5600-0D2A-4D43-B045-F7773C5C2D8D")
                },
                new Comment
                {
                    Id = new Guid("5CE3ED72-1029-41A2-A957-E9D61928105F"),
                    Body = "imperdiet sed euismod nisi porta lorem mollis aliquam ut porttitor leo a diam sollicitudin tempor id eu nisl nunc mi ipsum faucibus vitae aliquet nec",
                    PostDate = DateTime.Now,
                    UserId = "230669E4-C593-4084-BACC-E5A1AD1AD494",
                    TopicId = new Guid("5B365AD2-0264-46B2-86A8-C9C426EE88DD")
                },
                new Comment
                {
                    Id = new Guid("76D4CF19-B62D-4A1D-A9FE-DD1F34009C41"),
                    Body = "imperdiet sed euismod nisi porta lorem mollis aliquam ut porttitor leo a diam sollicitudin tempor id eu nisl nunc mi ipsum faucibus vitae aliquet nec",
                    PostDate = DateTime.Now,
                    UserId = "5CB83547-A7E4-4064-81AF-640D2B9ED831",
                    TopicId = new Guid("5B365AD2-0264-46B2-86A8-C9C426EE88DD")
                }
                );
        }
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "2BC27413-6F9C-49F0-BC95-4D040FDEDBB4", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "ED5264A9-7A3F-42E1-A653-6AEAC2CA2783", Name = "User", NormalizedName = "USER" }
            );
        }
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            PasswordHasher<IdentityUser> hasher = new();

            modelBuilder.Entity<IdentityUser>().HasData(
                    new IdentityUser()
                    {
                        Id = "24614412-A49F-4DC8-BCE1-EE5AFF9B11BC",
                        UserName = "admin@gmail.com",
                        NormalizedUserName = "ADMIN@GMAIL.COM",
                        Email = "admin@gmail.com",
                        NormalizedEmail = "ADMIN@GMAIL.COM",
                        EmailConfirmed = false,
                        PasswordHash = hasher.HashPassword(null!, "Admin123!"),
                        PhoneNumber = "555337681",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0
                    },
                    new IdentityUser()
                    {
                        Id = "CD04B747-A694-4431-8C8A-7CBF278A3832",
                        UserName = "gio@gmail.com",
                        NormalizedUserName = "GIO@GMAIL.COM",
                        Email = "gio@gmail.com",
                        NormalizedEmail = "GIO@GMAIL.COM",
                        EmailConfirmed = false,
                        PasswordHash = hasher.HashPassword(null!, "Gio123!"),
                        PhoneNumber = "589745665",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0
                    },
                    new IdentityUser()
                    {
                        Id = "230669E4-C593-4084-BACC-E5A1AD1AD494",
                        UserName = "nika@gmail.com",
                        NormalizedUserName = "NIKA@GMAIL.COM",
                        Email = "nika@gmail.com",
                        NormalizedEmail = "NIKA@GMAIL.COM",
                        EmailConfirmed = false,
                        PasswordHash = hasher.HashPassword(null!, "Nika123!"),
                        PhoneNumber = "558490645",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0
                    },
                    new IdentityUser()
                    {
                        Id = "1DF10D85-D5F8-4E4E-8892-92B740BF2F4F",
                        UserName = "saba@gmail.com",
                        NormalizedUserName = "SABA@GMAIL.COM",
                        Email = "saba@gmail.com",
                        NormalizedEmail = "SABA@GMAIL.COM",
                        EmailConfirmed = false,
                        PasswordHash = hasher.HashPassword(null!, "Saba123!"),
                        PhoneNumber = "5523901029",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0
                    },
                    new IdentityUser()
                    {
                        Id = "5CB83547-A7E4-4064-81AF-640D2B9ED831",
                        UserName = "beqa@gmail.com",
                        NormalizedUserName = "BEQA@GMAIL.COM",
                        Email = "beqa@gmail.com",
                        NormalizedEmail = "BEQA@GMAIL.COM",
                        EmailConfirmed = false,
                        PasswordHash = hasher.HashPassword(null!, "Beqa123!"),
                        PhoneNumber = "5233841070",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0
                    }
                    );
        }
        public static void SeedUserRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = "2BC27413-6F9C-49F0-BC95-4D040FDEDBB4", UserId = "24614412-A49F-4DC8-BCE1-EE5AFF9B11BC" },
                new IdentityUserRole<string> { RoleId = "ED5264A9-7A3F-42E1-A653-6AEAC2CA2783", UserId = "CD04B747-A694-4431-8C8A-7CBF278A3832" },
                new IdentityUserRole<string> { RoleId = "ED5264A9-7A3F-42E1-A653-6AEAC2CA2783", UserId = "230669E4-C593-4084-BACC-E5A1AD1AD494" },
                new IdentityUserRole<string> { RoleId = "ED5264A9-7A3F-42E1-A653-6AEAC2CA2783", UserId = "1DF10D85-D5F8-4E4E-8892-92B740BF2F4F" },
                new IdentityUserRole<string> { RoleId = "ED5264A9-7A3F-42E1-A653-6AEAC2CA2783", UserId = "5CB83547-A7E4-4064-81AF-640D2B9ED831" }
            );
        }
    }
}
