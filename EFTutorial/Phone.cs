//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFTutorial
{
    using System;
    using System.Collections.Generic;
    
    public partial class Phone
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public string ModelDetail { get; set; }
    
        public virtual Company Company { get; set; }
    }
}
