using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoFacDemo.Handle;
using AutoFacDemo.IHandle;
using Auto.Interface;
using Auto.Services;
using Microsoft.Extensions.Logging;

namespace AutoFacDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<TodayWriter>().As<IDateWriter>().SingleInstance();

            //ҵ���߼������ڳ��������ռ�
            Assembly service = Assembly.Load("Auto.Interface");
            //�ӿڲ����ڳ��������ռ�
            Assembly repository = Assembly.Load("Auto.Services");
            //�Զ�ע��
            builder.RegisterAssemblyTypes(service, repository)
                .Where(t => t.Name.EndsWith("Services"))
                .AsImplementedInterfaces();

            builder.RegisterType<calculator>().As<Icalculator>().SingleInstance();
            ////ע��ִ�������IRepository�ӿڵ�Repository��ӳ��
            //builder.RegisterGeneric(typeof(calculator))
            //    //InstancePerDependency��Ĭ��ģʽ��ÿ�ε��ã���������ʵ��������ÿ�����󶼴���һ���µĶ���
            //    .As(typeof(Icalculator)).InstancePerDependency();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
