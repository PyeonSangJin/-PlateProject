using UnityEngine;

public class Item 
{
    [SerializeField]
    private int m_price;

    [SerializeField]
    private string m_name;

    [SerializeField]
    private string m_description;

    public int Price {
        get { return m_price; }
        set { if (m_price != value) {
                m_price = value;
                //NotifyProperty("Price", value);
            } 
        }
    }

    public string Name {
        get { return m_name; }
        //set {
        //    if (m_name != value) {
        //        m_name = value;
        //        NotifyProperty("Name", value);
        //    }
        //}
    }

    public string Description {
        get { return m_description; }
        //set
        //{
        //    if (m_description != value)
        //    {
        //        m_description = value;
        //        NotifyProperty("Description", value);
        //    }
        //}
    }
}
