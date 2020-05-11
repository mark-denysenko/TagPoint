using Domain.Post;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Post
{
    public class TagSelectionConfiguration : IEntityTypeConfiguration<TagSelectionEntity>
    {
        public void Configure(EntityTypeBuilder<TagSelectionEntity> builder)
        {
            builder.ToTable("TagSelections");

            builder.HasKey(t => t.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            //builder.HasNoKey();
            builder.Property(x => x.Created).IsRequired().HasDefaultValueSql("GETDATE()");

        }
    }
}
