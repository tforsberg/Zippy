namespace Zipsurance2014.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Zipsurance2014.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Zipsurance2014.Models.TodoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TodoContext context)
        {
        }

    }
}
