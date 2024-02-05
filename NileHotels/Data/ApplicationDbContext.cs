using NileHotels.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NileHotels.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<HotelContactModal> HotelContactShow { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<HotelContact> HotelContacts { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomAsset> RoomAssets { get; set; }
        public DbSet<RoomStatus> RoomStatus { get; set; }
        public DbSet<RoomRecords> RoomRecords { get; set; }

        public DbSet<Asset> Assets { get; set; }

        public DbSet<AssetType> AssetTypes { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<StoreResponsable> StoreResponsables { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<AssetStatusType> AssetStatusTypes { get; set; }

        public DbSet<StoreAsset> StoreAssets { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<VendorContact> VendorContacts { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<PurchaseItem> PurchaseItems { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Curncy> Curncy { get; set; }
        public DbSet<Terms> Terms { get; set; }
        public DbSet<IdType> IdType { get; set; }
        public DbSet<UnitType> UnitType { get; set; }


        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyContact> CompanyContact { get; set; }
        public DbSet<CustomerContact> CustomerContacts { get; set; }

        public DbSet<Contracts> Contractss { get; set; }

        public DbSet<PurposeVisit> PurposeVisits { get; set; }

        public DbSet<TaxType> TaxTypes { get; set; }

        public DbSet<ContractInvoice> ContractInvoices { get; set; }

        public DbSet<ContractTax> ContractTaxes { get; set; }

        public DbSet<ContractRecepitVoucher> ContractRecepitVouchers { get; set; }

        public DbSet<FutureReservision> FutureReservisions { get; set; }

        public DbSet<ContractPaymentVoucher> ContractPaymentVouchers { get; set; }

        public DbSet<PaymentType> PaymentTypes { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<ServiceItem> ServiceItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<HotelContactModal>(a =>
            {
                a.ToView("HotelContactShow");
                a.HasNoKey();
            });
            modelBuilder.Entity<Hotel>().HasMany(h => h.Rooms).WithOne(r => r.Hotel).HasForeignKey(r => r.HotelId);

            modelBuilder.Entity<Hotel>().HasMany(h => h.Vendors).WithOne(v => v.Hotel).HasForeignKey(v => v.HotelId);

            modelBuilder.Entity<Hotel>().HasMany(h => h.Services).WithOne(s => s.Hotel).HasForeignKey(s => s.HotelId);

            modelBuilder.Entity<HotelContact>()
    .HasOne(hc => hc.Hotel)
    .WithMany(h => h.HotelContact)
    .HasForeignKey(hc => hc.HotelId)
    .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<CompanyContact>()
    .HasOne(hc => hc.Company)
    .WithMany(h => h.CompanyContact)
    .HasForeignKey(hc => hc.CompanyId)
    .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Asset>()
   .HasOne(hc => hc.Hotel)
   .WithMany(h => h.Asset)
   .HasForeignKey(hc => hc.HotelId)
   .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vendor>()
   .HasOne(hc => hc.Country)
   .WithMany(h => h.Vendor)
   .HasForeignKey(hc => hc.CityId)
   .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaxType>()
   .HasOne(hc => hc.Hotel)
   .WithMany(h => h.TaxType)
   .HasForeignKey(hc => hc.HotelId)
   .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Service>()
   .HasOne(hc => hc.Customer)
   .WithMany(h => h.Service)
   .HasForeignKey(hc => hc.CustomerId)
   .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Service>()
   .HasOne(hc => hc.Store)
   .WithMany(h => h.Service)
   .HasForeignKey(hc => hc.StoreId)
   .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>()
   .HasOne(hc => hc.Hotel)
   .WithMany(h => h.Customer)
   .HasForeignKey(hc => hc.HotelId)
   .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
    .HasOne(e => e.Hotel)
    .WithMany(h => h.Employee)
    .HasForeignKey(e => e.HotelId)
    .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Booking>()
    .HasOne(b => b.Room)
    .WithMany(r => r.Booking)
    .HasForeignKey(b => b.RoomId)
    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RoomAsset>()
    .HasOne(ra => ra.Asset)
    .WithMany(a => a.RoomAssets)
    .HasForeignKey(ra => ra.AssetId)
    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StoreResponsable>()
    .HasOne(sr => sr.Store)
    .WithMany(s => s.StoreResponsables)
    .HasForeignKey(sr => sr.StoreId)
    .OnDelete(DeleteBehavior.NoAction);

    //        modelBuilder.Entity<Purchase>()
    //.HasOne(p => p.Store)
    //.WithMany(s => s.Purchases)
    //.HasForeignKey(p => p.StoreId)
    //.OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Purchase>()
    .HasOne(p => p.Vendor)
    .WithMany(v => v.Purchases)
    .HasForeignKey(p => p.VendorId)
    .OnDelete(DeleteBehavior.NoAction);

    //        modelBuilder.Entity<Contracts>()
    //.HasOne(c => c.FutureReservision)
    //.WithMany(fr => fr.Contracts)
    //.HasForeignKey(c => c.FutureReservisionId)
    //.OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ContractInvoice>()
    .HasOne(ci => ci.Customer)
    .WithMany(c => c.ContractInvoices)
    .HasForeignKey(ci => ci.CustomerId)
    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Service>()
    .HasOne(s => s.Hotel)
    .WithMany(h => h.Services)
    .HasForeignKey(s => s.HotelId)
    .OnDelete(DeleteBehavior.NoAction);


            //modelBuilder.Entity<ContractRecepitVoucher>()
            //    .HasOne(cr => cr.Currency)
            //    .WithMany()
            //    .HasForeignKey(cr => cr.CurrencyId)
            //    .OnDelete(DeleteBehavior.NoAction);
  
            modelBuilder.Entity<ContractRecepitVoucher>()
.HasOne(cpv => cpv.Contract)
.WithMany()
.HasForeignKey(cpv => cpv.ContractId)
.OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Room>().HasMany(r => r.RoomAssets).WithOne(ra => ra.Room).HasForeignKey(ra => ra.RoomId).OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Asset>().HasMany(a => a.RoomAssets).WithOne(ra => ra.Asset).HasForeignKey(ra => ra.AssetId);

            modelBuilder.Entity<Store>().HasMany(s => s.StoreAssets).WithOne(sa => sa.Store).HasForeignKey(sa => sa.StoreId);

            modelBuilder.Entity<Asset>().HasMany(a => a.StoreAssets).WithOne(sa => sa.Asset).HasForeignKey(sa => sa.AssetId).OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Purchase>().HasMany(p => p.PurchaseItems).WithOne(pi => pi.Purchase).HasForeignKey(pi => pi.PurchaseId).OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Contracts>().HasMany(c => c.ContractInvoices).WithOne(ci => ci.Contract).HasForeignKey(ci => ci.ContractId);

            modelBuilder.Entity<Contracts>().HasMany(c => c.ContractTaxes).WithOne(ct => ct.Contract).HasForeignKey(ct => ct.ContractId);

            modelBuilder.Entity<Contracts>().HasMany(c => c.ContractRecepitVouchers).WithOne(crv => crv.Contract).HasForeignKey(crv => crv.ContractId);

            modelBuilder.Entity<Contracts>().HasMany(c => c.ContractPaymentVouchers).WithOne(crv => crv.Contract).HasForeignKey(crv => crv.ContractId);

            modelBuilder.Entity<Contracts>()
        .HasOne(c => c.Room)
        .WithMany(r => r.Contracts)
        .HasForeignKey(c => c.RoomId)
        .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Contracts>()
    .HasOne(c => c.Hotel)
    .WithMany(r => r.Contracts)
    .HasForeignKey(c => c.HotelId)
.OnDelete(DeleteBehavior.ClientSetNull);

            //        modelBuilder.Entity<PurchaseItem>()
            //.HasOne(pi => pi.RoomAsset)
            //.WithMany(ra => ra.PurchaseItem)
            //.HasForeignKey(pi => pi.RoomAssetId)
            //.OnDelete(DeleteBehavior.NoAction).OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<FutureReservision>()
        .HasOne<Customer>(f => f.Customer)
        .WithMany()
        .HasForeignKey(f => f.CustomerId)
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FutureReservision>()
                .HasOne<Hotel>(f => f.Hotel)
                .WithMany()
                .HasForeignKey(f => f.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FutureReservision>()
                .HasOne<RoomType>(f => f.RoomType)
                .WithMany()
                .HasForeignKey(f => f.RoomTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FutureReservision>()
                .HasOne<PurposeVisit>(f => f.PurposeVisit)
                .WithMany()
                .HasForeignKey(f => f.PurposeVisitId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contracts>().HasMany(c => c.ContractPaymentVouchers).WithOne(cp => cp.Contract).HasForeignKey(cp => cp.ContractId);

            modelBuilder.Entity<Service>().HasMany(s => s.ServiceItems).WithOne(si => si.Service).HasForeignKey(si => si.ServiceId);
            modelBuilder.Entity<ContractTax>()
            .HasOne(ct => ct.Contract)
            .WithMany(c => c.ContractTaxes)
            .HasForeignKey(ct => ct.ContractId);



            modelBuilder.Entity<ContractTax>()
                .HasOne(ct => ct.TaxType)
                .WithMany(t => t.ContractTaxes)
                .HasForeignKey(ct => ct.TaxTypeId);


           



        }

        public DbSet<Booking> Booking { get; set; } = default!;

        public DbSet<BookingAsset> BookingAsset { get; set; } = default!;

        public DbSet<ContactType> ContactType { get; set; } = default!;

        public DbSet<Payment> Payment { get; set; } = default!;

        public DbSet<RoomType> RoomType { get; set; } = default!;

        public DbSet<StoreMotion> StoreMotion { get; set; } = default!;

    }
}