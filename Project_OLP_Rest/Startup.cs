using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Project_OLP_Rest.Data;
using Microsoft.EntityFrameworkCore;
using Project_OLP_Rest.Data.Interfaces;
using Project_OLP_Rest.Data.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RiskFirst.Hateoas;
using Project_OLP_Rest.Domain;

namespace Project_OLP_Rest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "My API",
                    Description = "Placeholder description",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Talking Dotnet", Email = "asdf@email.com", Url = "nourl.com" }
                });
            });

                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options =>
                {
                    options.Authority = Configuration["Auth0:Authority"];
                    options.Audience = Configuration["Auth0:Audience"];
                });

            services
                .AddMvc()
                .AddHateoas(options =>
                {
                    options
                        //Courses
                        //  .AddLink<Course>("get-courses", p => new { id = p.CourseId })
                        .AddLink<Course>("get-course", c => new { id = c.CourseId })
                        .AddLink<List<Course>>("add-course")
                        .AddLink<Course>("update-course", c => new { id = c.CourseId })
                        .AddLink<Course>("delete-course", c => new { id = c.CourseId })
                        //ChatBots
                        // .AddLink<ChatBot>("getchatBots", p => new { id = p.ChatBotId })
                        .AddLink<ChatBot>("getchatBot", ch => new { id = ch.ChatBotId })
                        .AddLink<List<ChatBot>>("add-chatBot")
                        .AddLink<ChatBot>("update-chatBot", ch => new { id = ch.ChatBotId })
                        .AddLink<ChatBot>("delete-chatBot", ch => new { id = ch.ChatBotId })
                        //Groups
                       // .AddLink<Group>("get-groups", p => new { id = p.GroupId })
                        .AddLink<Group>("get-group", g => new { id = g.GroupId })
                        .AddLink<List<Group>>("add-group")
                        .AddLink<Group>("update-group", g => new { id = g.GroupId })
                        .AddLink<Group>("delete-group", g => new { id = g.GroupId })
                        //Modules
                        //  .AddLink<Module>("get-modules", p => new { id = p.ModuleId })
                        .AddLink<Module>("get-module", m => new { id = m.ModuleId })
                        .AddLink<List<Module>>("add-module")
                        .AddLink<Module>("update-module", m => new { id = m.ModuleId })
                        .AddLink<Module>("delete-module", m => new { id = m.ModuleId })
                        //ChatSession
                        //  .AddLink<ChatSession>("get-chatSessions", p => new { id = p.ChatSessionId })
                        .AddLink<ChatSession>("get-chatSession", s => new { id = s.ChatSessionId })
                        .AddLink<List<ChatSession>>("add-chatSession")
                        .AddLink<ChatSession>("update-chatSession", s => new { id = s.ChatSessionId })
                        .AddLink<ChatSession>("delete-chatSession", s => new { id = s.ChatSessionId })
                        //Records
                        //  .AddLink<Record>("get-records", p => new { id = p.RecordId })
                        .AddLink<Record>("get-record", r => new { id = r.RecordId })
                        .AddLink<List<Record>>("add-record")
                        .AddLink<Record>("update-record", r => new { id = r.RecordId })
                        .AddLink<Record>("delete-record", r => new { id = r.RecordId });
                });    

                services.AddDbContext<OLP_Context>(
                    options => options.UseSqlServer(
                         Configuration.GetConnectionString("OLPConnection")));

                services.AddTransient<IGroupService, GroupService>();
                services.AddTransient<ICourseService, CourseService>();
                services.AddTransient<IModuleService, ModuleService>();
                services.AddTransient<IChatBotService, ChatBotService>();
                services.AddTransient<IChatSessionService, ChatSessionService>();
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                
                app.UseAuthentication();

                app.UseMvc();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }
        }
    }


