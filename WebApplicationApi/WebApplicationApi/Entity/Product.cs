//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationApi.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public System.Guid ID { get; set; }
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> Amount { get; set; }
    
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
