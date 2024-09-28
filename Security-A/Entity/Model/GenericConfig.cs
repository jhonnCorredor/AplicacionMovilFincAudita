using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entity.Model.Security;

namespace Entity.Model
{
    internal class GenericConfig
    {
        public void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(i => i.Username).IsUnique();
            builder.HasIndex(i => i.PersonId).IsUnique();
        }
        public void ConfigurePerson(EntityTypeBuilder<Person> builder)
        {
            builder.HasIndex(i => i.Document).IsUnique();
            builder.HasIndex(i => i.Email).IsUnique();
            builder.HasIndex(i => i.Phone).IsUnique();
        }
    }
}
