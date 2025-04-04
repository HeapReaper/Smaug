﻿using System.Collections.Generic;
using System.IO;

namespace Smaug.RulesMeta.File
{
    class MetaRuleName : MetaRule
    {
        private HashSet<string> AcceptNames { get; } = new HashSet<string>()
        {
            /* Active Directory */
            "ntds.dit",
            "sam",
            "security",
            "system",
             
            /* Credential files */
            ".htpasswd",                        // Apache
            "config.rb",                        // Chef
            "knife.rb",                         // Chef
            "login data",                       // Chrome
            "cacpmscanner.exe.config",          // CyberArk
            "padr.ini",                         // CyberArk
            "paragent.ini",                     // CyberArk
            "pvconfiguration.xml",              // CyberArk
            "vault.ini",                        // CyberArk
            ".dbeaver-data-sources.xml",        // DBeaver
            "credentials-config.json",          // DBeaver
            "data-sources.json",                // DBeaver
            ".dockercfg",                       // Docker
            "recentservers.xml",                // FileZilla
            "filezilla.xml",                    // FileZilla
            "key3.db",                          // Firefox
            "key4.db",                          // Firefox
            "logins.json",                      // Firefox
            ".git-credentials",                 // Git
            ".gitconfig",                       // Git
            "credentials.xml",                  // Jenkins
            "master.key",                       // Jenkins
            "hudson.util.secret",               // Jenkins
            "jenkins.plugins.publish_over_ssh.bapsshpublisherplugin.xml",
            "localsettings.php",                // MediaWiki
            "mobaxterm.ini",                    // MobaXterm
            "confcons.xml",                     // MremoteNG
            "mru.dat",                          // MSSQL
            "sqlstudio.bin",                    // MSSQL
            "usersettings.xml",                 // MSSQL
            "pwd.db",                           // OpenBSD
            "accounts.xml",                     // Pidgin
            ".pgpass",                          // PostgreSQL
            "proftpdpasswd",                    // ProFTPd
            "credentials",                      // RubyGems
            "secret_token.rb",                  // Ruby on Rails
            "secrets.yml",                      // Ruby on Rails > 4
            "database.yml",                     // Ruby on Rails > 4
            "sftp-config.json",                 // Sublime SFTP
            "passwd",                           // Unix
            "shadow",                           // Unix
            "customsettings.ini",               // Windows
            "autounattend.xml",                 // Windows
            "unattend.xml",                     // Windows
            "sensorconfiguration.json",         // Windows Defender
            
            /* History files */
            ".bash_history",                    // Bash
            ".sh_history",                      // Sh
            ".zhistory",                        // Zsh
            ".zsh_history",                     // Zsh
            ".mysql_history",                   // MySQL
            ".psql_history",                    // PostgreSQL
            ".irb_history",                     // Ruby
            ".python_history",                  // Python
            "consolehost_history.txt",          // PowerShell
            
            /* Resource files */
            ".bashrc",                          // Bash
            ".profile",                         // Bash
            ".cshrc",                           // C shell
            ".netrc",                           // Curl (Unix)
            "_netrc",                           // Curl (Windows)
            ".env",                             // NodeJS
            ".npmrc",                           // NodeJS Package Manager (npm)
            ".zshrc",                           // Zsh

            /* SSH files */
            "id_rsa",
            "id_dsa",
            "id_ecdsa",
            "id_ed25519",
        };

        private HashSet<string> RejectNames { get; } = new HashSet<string>()
        {

        };

        public override bool? TestRule(string path)
        {
            var name = Path.GetFileName(path);

            if (!string.IsNullOrEmpty(name))
            {
                var temp = name.ToLower();

                if (RejectNames.Contains(temp))
                    return false;
                else if (AcceptNames.Contains(temp))
                    return true;
            }

            return null;
        }

        public override string ToString()
        {
            return "meta:name";
        }
    }
}
