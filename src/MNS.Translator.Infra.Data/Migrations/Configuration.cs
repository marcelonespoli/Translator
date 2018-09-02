namespace MNS.Translator.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MNS.Translator.Infra.Data.Context.TranslatorContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

    }
}
