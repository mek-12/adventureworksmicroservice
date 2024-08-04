namespace HumanResources.Service.Domain.Entities {
    public class Department {
        // Benzersiz kimlik (Primary Key)
        public short DepartmentID { get; private set; }

        // Departman adı
        public string Name { get; private set; }

        // Departmanın ait olduğu grup adı
        public string GroupName { get; private set; }

        // Kayıtların en son güncellendiği tarih ve saat
        public DateTime ModifiedDate { get; private set; }

        // Constructor (Oluşturucu)
        private Department() { }

        public Department(string name, string groupName) {
            Name = name;
            GroupName = groupName;
            ModifiedDate = DateTime.Now;
        }

        // Departman adını güncelleme işlevi
        public void UpdateName(string newName) {
            Name = newName;
            ModifiedDate = DateTime.Now;
        }

        // Grup adını güncelleme işlevi
        public void UpdateGroupName(string newGroupName) {
            GroupName = newGroupName;
            ModifiedDate = DateTime.Now;
        }
    }
}
