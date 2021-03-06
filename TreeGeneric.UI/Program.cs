﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeGeneric.BussinessLogic;
using TreeGeneric.Data;

namespace TreeGeneric.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ApplicationDbContext>().As<ApplicationDbContext>();



            //builder.RegisterType<Repository<TreeGeneric.Model.Region>>().As<Repository<TreeGeneric.Model.Region>>();
            //builder.RegisterType<PlantingRepository>().As<IPlantingRepository>();
            //builder.RegisterType<UserRepository>().As<IUserRepository>();
            //builder.RegisterType<TreeTypeRepository>().As<ITreeTypeRepository>();
            //builder.RegisterType<DonationRepository>().As<IDonationRepository>();
            //builder.RegisterType<PostRepository>().As<IPostRepository>();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(Repository<>));


            //Servisler tek oluşturulacak
            builder.RegisterType<RegionService>().As<IRegionService>();
            builder.RegisterType<PlantingService>().As<IPlantingService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<TreeTypeService>().As<ITreeTypeService>();
            builder.RegisterType<DonationService>().As<IDonationService>();
            builder.RegisterType<PostService>().As<IPostService>();


            var container = builder.Build();


            using (var scope = container.BeginLifetimeScope())
            {
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FrmSplash());
                }
            }
        }
    }
}

