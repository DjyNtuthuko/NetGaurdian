using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;

namespace NetGaurdian
{
    internal class Bot


namespace NetGuardian
    {
        // Holds data for a single cybersecurity topic
        internal class Topic
        {
            public string[] Keywords { get; set; }
            public string[] Responses { get; set; }
            public string FollowUp { get; set; }

            public Topic(string[] keywords, string[] responses, string followUp = "")
            {
                Keywords = keywords;
                Responses = responses;
                FollowUp = followUp;
            }
        }

        internal class Bot
        {
            private List<string> history = new List<string>();
            private List<Topic> topics = new List<Topic>();
            private Random rand = new Random();

            // Register all topics when Bot is created
            public Bot()
            {
                topics.Add(new Topic(
                    new[] { "ransomware" },
                    new[]
                    {
                    "Ransomware holds your files hostage until you pay up. Your best weapon against it? Regular backups.",
                    "Getting hit by ransomware can wipe out everything on your device. Offline backups are a lifesaver.",
                    "Ransomware attackers rely on panic. If you back up your data routinely, they have nothing over you."
                    },
                    "Backups are the number one defence against ransomware. Ask me about backups!"
                ));

                topics.Add(new Topic(
                    new[] { "data breach", "breach", "leaked", "leak" },
                    new[]
                    {
                    "A data breach means your personal info got into the wrong hands. Change passwords fast if you think you're affected.",
                    "Breaches happen when attackers get into a system and steal user data. Check if your email has been exposed on haveibeenpwned.com.",
                    "After a breach your info can end up sold online. Act quickly, change passwords and enable 2FA."
                    },
                    "Ask me about identity theft to see what can happen when your data gets out."
                ));

                topics.Add(new Topic(
                    new[] { "firewall" },
                    new[]
                    {
                    "A firewall watches your network traffic and blocks anything that looks suspicious. Think of it as a bouncer for your connection.",
                    "Firewalls are your first line of defence on a network. Both hardware and software firewalls matter.",
                    "Without a firewall, your device is basically wide open to the internet. Keep it on at all times."
                    },
                    "Ask me about network security to see how firewalls fit into the bigger picture."
                ));

                topics.Add(new Topic(
                    new[] { "safe browsing", "browsing", "browser" },
                    new[]
                    {
                    "Always check for HTTPS before entering any personal info on a website. That padlock icon matters.",
                    "Sketchy links are one of the easiest ways attackers get in. If you weren't expecting a link, don't click it.",
                    "Keeping your browser updated closes security holes that hackers love to exploit."
                    },
                    "Ask me about scams to learn how dodgy websites are used to trick people."
                ));

                topics.Add(new Topic(
                    new[] { "identity theft", "identity", "stolen identity" },
                    new[]
                    {
                    "Identity theft is when someone uses your personal info to impersonate you, often to steal money or open accounts.",
                    "Attackers piece together info from social media, breaches and scams to steal your identity. Be careful what you post.",
                    "If your identity gets stolen, it can take months to sort out. Staying private online is the best prevention."
                    },
                    "Data breaches are a major cause of identity theft. Ask me about data breaches!"
                ));

                topics.Add(new Topic(
                    new[] { "dark web" },
                    new[]
                    {
                    "The dark web is a hidden part of the internet where stolen data, passwords and identities are often bought and sold.",
                    "Your info could already be on the dark web without you knowing it. Check haveibeenpwned.com to see if you've been exposed.",
                    "Most people never need to go near the dark web. If your data lands there after a breach, act fast and change everything."
                    },
                    "Ask me about data breaches to understand how your info ends up on the dark web."
                ));

                topics.Add(new Topic(
                    new[] { "encryption", "encrypt", "encrypted" },
                    new[]
                    {
                    "Encryption scrambles your data so only the right person with the right key can read it. It powers everything from WhatsApp to online banking.",
                    "When you see HTTPS in the address bar, that means the connection is encrypted. Your data is much safer.",
                    "End-to-end encryption means not even the app provider can read your messages. Look for it in messaging apps you trust."
                    },
                    "Ask me about safe browsing to see encryption in action on websites."
                ));

                topics.Add(new Topic(
                    new[] { "network security", "network" },
                    new[]
                    {
                    "Network security is about keeping your connection and devices protected from unauthorised access. It starts with a good router password and firewall.",
                    "A lot of people forget to secure their home network. Change your router's default password and hide your WiFi name if you can.",
                    "Attackers scan for unsecured networks all the time. A simple strong password and a firewall go a long way."
                    },
                    "Ask me about firewalls for one of the core tools in network security."
                ));

                topics.Add(new Topic(
                    new[] { "backup", "back up", "backups" },
                    new[]
                    {
                    "Backups are your safety net. If anything goes wrong, you can restore everything without paying a cent to attackers.",
                    "Use the 3-2-1 rule: 3 copies of your data, 2 on different devices, 1 stored offsite or in the cloud.",
                    "A lot of ransomware victims lose everything because they never backed up. Don't let that be you."
                    },
                    "Ask me about ransomware to see exactly why backups are so critical."
                ));

                topics.Add(new Topic(
                    new[] { "scam", "scams", "fraud" },
                    new[]
                    {
                    "Online scams often use urgency to panic you into clicking or paying without thinking. Slow down and verify first.",
                    "If someone online is promising you money, prizes or deals that seem too good to be true, it's almost certainly a scam.",
                    "Scammers impersonate banks, courier companies and even government departments. Always contact organisations directly."
                    },
                    "Ask me about safe browsing to avoid landing on scam websites."
                ));

                topics.Add(new Topic(
                    new[] { "password", "passwords" },
                    new[]
                    {
                    "Every account should have its own unique password. Reusing passwords means one breach can unlock everything.",
                    "A strong password is long, random and has no personal info in it. A password manager can handle all of this for you.",
                    "Avoid anything obvious like your name, birthday or favourite team. Attackers try those first."
                    },
                    "Pair strong passwords with 2FA for a serious upgrade in security. Ask me about 2FA!"
                ));

                topics.Add(new Topic(
                    new[] { "2fa", "two factor", "authentication", "mfa" },
                    new[]
                    {
                    "Two-Factor Authentication means a stolen password alone is not enough to get into your account. The attacker still needs that second code.",
                    "Use an authenticator app over SMS for 2FA where possible. SMS codes can be intercepted.",
                    "2FA is one of the most effective ways to stop account takeovers. Turn it on for every account that supports it."
                    },
                    "Ask me about passwords to build a strong security combo with 2FA."
                ));

                topics.Add(new Topic(
                    new[] { "antivirus", "anti virus" },
                    new[]
                    {
                    "Antivirus software watches for harmful programs trying to run on your device and stops them before they cause damage.",
                    "A good antivirus tool catches malware, spyware and ransomware. Keep it updated so it knows the latest threats.",
                    "Don't rely on antivirus alone but it's an important layer in your overall defence."
                    },
                    "Ask me about firewalls to add another layer on top of your antivirus."
                ));
            }
        }
    }
    {
    }
}
