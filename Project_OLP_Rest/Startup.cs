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
                .AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling
                        = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddHateoas(options =>
                 {
                     options
                        //Groups
                        .AddLink<Group>("get-groups", p => new { id = p.GroupId })
                        .AddLink<Group>("get-group", p => new { id = p.GroupId })
                        .AddLink<List<Group>>("add-group")
                        .AddLink<Group>("edit-group", p => new { id = p.GroupId })
                        .AddLink<Group>("delete-group", p => new { id = p.GroupId })
                        //ChatBots 
                        .AddLink<Domain.ChatBot>("get-chatbots", p => new { id = p.ChatBotId })
                        .AddLink<Domain.ChatBot>("get-chatbot", p => new { id = p.ChatBotId })
                        .AddLink<List<Domain.ChatBot>>("add-chatbot")
                        .AddLink<Domain.ChatBot>("edit-chatbot", p => new { id = p.ChatBotId })
                        .AddLink<Domain.ChatBot>("delete-chatbot", p => new { id = p.ChatBotId })
                        //Courses
                        .AddLink<Course>("get-courses", p => new { id = p.CourseId })
                        .AddLink<Course>("get-course", p => new { id = p.CourseId })
                        .AddLink<List<Course>>("add-course")
                        .AddLink<Course>("edit-course", p => new { id = p.CourseId })
                        .AddLink<Course>("delete-course", p => new { id = p.CourseId })
                        //Modules
                        .AddLink<Module>("get-modules", p => new { id = p.ModuleId })
                        .AddLink<Module>("get-module", p => new { id = p.ModuleId })
                        .AddLink<List<Module>>("add-module")
                        .AddLink<Module>("edit-module", p => new { id = p.ModuleId })
                        .AddLink<Module>("delete-module", p => new { id = p.ModuleId })
                        //Records
                        .AddLink<Record>("get-records", p => new { id = p.RecordId })
                        .AddLink<Record>("get-record", p => new { id = p.RecordId })
                        .AddLink<List<Record>>("add-record")
                        .AddLink<Record>("edit-record", p => new { id = p.RecordId })
                        .AddLink<Record>("delete-record", p => new { id = p.RecordId })
                        //ChatSession
                        .AddLink<ChatSession>("get-sessions", p => new { id = p.ChatSessionId })
                        .AddLink<ChatSession>("get-session", p => new { id = p.ChatSessionId })
                        .AddLink<List<ChatSession>>("add-session")
                        .AddLink<ChatSession>("edit-session", p => new { id = p.ChatSessionId })
                        .AddLink<ChatSession>("delete-session", p => new { id = p.ChatSessionId });

                 });
                     

            services.AddDbContext<OlpContext>(
                options => options.UseSqlServer(
                     Configuration.GetConnectionString("OLPConnection")));

            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IModuleService, ModuleService>();
            services.AddTransient<IChatBotService, ChatBotService>();
            services.AddTransient<IChatSessionService, ChatSessionService>();
            services.AddTransient<IRecordService, RecordService>();
            services.AddTransient<IExerciseService, ExerciseService>();
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
