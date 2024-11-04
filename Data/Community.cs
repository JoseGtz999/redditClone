using System;
using System.Collections.Generic;

public class Community
{
    public int CommunityID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public int? OwnerID { get; set; }

    public virtual User Owner { get; set; }
    public virtual ICollection<Post> Posts { get; set; }
}
