﻿using DDDNetCore.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDNetCore.Infraestructure.Operation
{
    internal class OperationEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Operation.Operation>
    {
        public void Configure(EntityTypeBuilder<Domain.Operation.Operation> builder)
        {
            // cf. https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx
            
            //builder.ToTable("Operation", SchemaNames.DDDSample1);
            builder.HasKey(b => b.Id);
            //builder.Property<bool>("_active").HasColumnName("Active");
        }
    }
}