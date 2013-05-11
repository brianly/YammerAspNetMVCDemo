using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YammerAuthentication.Yammer
{
    public class EmailAddress
    {
        public string address { get; set; }
        public string type { get; set; }
    }

    public class Im
    {
        public string provider { get; set; }
        public string username { get; set; }
    }

    public class Contact
    {
        public bool has_fake_email { get; set; }
        public List<EmailAddress> email_addresses { get; set; }
        public List<object> phone_numbers { get; set; }
        public Im im { get; set; }
    }

    public class Stats
    {
        public int following { get; set; }
        public int followers { get; set; }
        public int updates { get; set; }
    }

    public class Settings
    {
        public string xdr_proxy { get; set; }
    }

    public class User
    {
        public Contact contact { get; set; }
        public string network_name { get; set; }
        public string location { get; set; }
        public string last_name { get; set; }
        public List<object> previous_companies { get; set; }
        public string birth_date { get; set; }
        public string timezone { get; set; }
        public string first_name { get; set; }
        public string job_title { get; set; }
        public string significant_other { get; set; }
        public string state { get; set; }
        public List<object> schools { get; set; }
        public Stats stats { get; set; }
        public object department { get; set; }
        public List<object> external_urls { get; set; }
        public string name { get; set; }
        public string mugshot_url { get; set; }
        public string full_name { get; set; }
        public string interests { get; set; }
        public string activated_at { get; set; }
        public string kids_names { get; set; }
        public Settings settings { get; set; }
        public bool show_ask_for_photo { get; set; }
        public string admin { get; set; }
        public object hire_date { get; set; }
        public List<string> network_domains { get; set; }
        public string type { get; set; }
        public string verified_admin { get; set; }
        public string web_url { get; set; }
        public string summary { get; set; }
        public int network_id { get; set; }
        public string mugshot_url_template { get; set; }
        public object guid { get; set; }
        public int id { get; set; }
        public string url { get; set; }
        public string can_broadcast { get; set; }
        public string expertise { get; set; }
    }

    public class AccessToken
    {
        public string network_name { get; set; }
        public bool modify_messages { get; set; }
        public bool modify_subscriptions { get; set; }
        public object expires_at { get; set; }
        public bool view_tags { get; set; }
        public string network_permalink { get; set; }
        public string authorized_at { get; set; }
        public string token { get; set; }
        public int network_id { get; set; }
        public int user_id { get; set; }
        public bool view_subscriptions { get; set; }
        public bool view_messages { get; set; }
        public string created_at { get; set; }
        public bool view_members { get; set; }
        public bool view_groups { get; set; }
    }

    public class ProfileFieldsConfig
    {
        public bool enable_work_phone { get; set; }
        public bool enable_job_title { get; set; }
        public bool enable_mobile_phone { get; set; }
    }

    public class Network
    {
        public bool is_chat_enabled { get; set; }
        public bool community { get; set; }
        public bool show_upgrade_banner { get; set; }
        public bool paid { get; set; }
        public bool is_org_chart_enabled { get; set; }
        public ProfileFieldsConfig profile_fields_config { get; set; }
        public string permalink { get; set; }
        public string navigation_text_color { get; set; }
        public string name { get; set; }
        public bool is_group_enabled { get; set; }
        public bool moderated { get; set; }
        public string type { get; set; }
        public string web_url { get; set; }
        public string header_text_color { get; set; }
        public int id { get; set; }
        public bool is_translation_enabled { get; set; }
        public string created_at { get; set; }
        public string navigation_background_color { get; set; }
        public string header_background_color { get; set; }
    }

    public class YammerToken
    {
        public User user { get; set; }
        public AccessToken access_token { get; set; }
        public Network network { get; set; }
    }
}