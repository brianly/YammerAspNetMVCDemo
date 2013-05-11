using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YammerAuthentication.Yammer.Models.User
{
    public class HomeTab
    {
        public string name { get; set; }
        public string type { get; set; }
        public string ordering_index { get; set; }
        public string feed_description { get; set; }
        public string url { get; set; }
        public string select_name { get; set; }
        public bool? @private { get; set; }
        public int? group_id { get; set; }
    }

    public class NetworkSettings
    {
        public bool allow_inline_document_view { get; set; }
        public string admin_can_delete_messages { get; set; }
        public bool enable_private_messages { get; set; }
        public bool allow_inline_video { get; set; }
        public bool show_communities_directory { get; set; }
        public bool enable_chat { get; set; }
        public string message_prompt { get; set; }
        public string allow_attachments { get; set; }
        public bool allow_yammer_apps { get; set; }
        public bool allow_external_sharing { get; set; }
        public bool enable_groups { get; set; }
    }

    public class WebPreferences
    {
        public string threaded_mode { get; set; }
        public bool dismissed_profile_prompt { get; set; }
        public bool sticky_my_feed { get; set; }
        public string dismissed_invite_tooltip_at { get; set; }
        public string enter_does_not_submit_message { get; set; }
        public List<HomeTab> home_tabs { get; set; }
        public bool dismissed_group_tooltip { get; set; }
        public bool dismissed_apps_tooltip { get; set; }
        public NetworkSettings network_settings { get; set; }
        public string enable_chat { get; set; }
        public bool dismissed_feed_tooltip { get; set; }
        public string absolute_timestamps { get; set; }
        public bool dismissed_invite_tooltip { get; set; }
        public string show_full_names { get; set; }
        public string prescribed_my_feed { get; set; }
        public string preferred_my_feed { get; set; }
    }

    public class Settings
    {
        public string xdr_proxy { get; set; }
    }

    public class Stats
    {
        public int followers { get; set; }
        public int updates { get; set; }
        public int following { get; set; }
    }

    public class EmailAddress
    {
        public string type { get; set; }
        public string address { get; set; }
    }

    public class Im
    {
        public string username { get; set; }
        public string provider { get; set; }
    }

    public class Contact
    {
        public List<EmailAddress> email_addresses { get; set; }
        public Im im { get; set; }
        public bool has_fake_email { get; set; }
        public List<object> phone_numbers { get; set; }
    }

    public class YammerUser
    {
        public string network_name { get; set; }
        public string name { get; set; }
        public string admin { get; set; }
        public List<object> external_urls { get; set; }
        public string type { get; set; }
        public int id { get; set; }
        public bool show_ask_for_photo { get; set; }
        public string location { get; set; }
        public string activated_at { get; set; }
        public string expertise { get; set; }
        public string can_broadcast { get; set; }
        public string timezone { get; set; }
        public string job_title { get; set; }
        public string mugshot_url_template { get; set; }
        public string first_name { get; set; }
        public object hire_date { get; set; }
        public string web_url { get; set; }
        public string full_name { get; set; }
        public string url { get; set; }
        public List<object> previous_companies { get; set; }
        public string last_name { get; set; }
        public WebPreferences web_preferences { get; set; }
        public string mugshot_url { get; set; }
        public bool follow_general_messages { get; set; }
        public object department { get; set; }
        public List<object> schools { get; set; }
        public string summary { get; set; }
        public string birth_date { get; set; }
        public object guid { get; set; }
        public string kids_names { get; set; }
        public Settings settings { get; set; }
        public List<string> network_domains { get; set; }
        public string significant_other { get; set; }
        public string interests { get; set; }
        public string verified_admin { get; set; }
        public int network_id { get; set; }
        public Stats stats { get; set; }
        public Contact contact { get; set; }
        public string state { get; set; }
    }
}