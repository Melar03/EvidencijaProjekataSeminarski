{
  "version": 3,
  "targets": {
    ".NETFramework,Version=v4.8.1": {
      "EntityFramework/6.5.1": {
        "type": "package",
        "frameworkAssemblies": [
          "System.ComponentModel.DataAnnotations"
        ],
        "compile": {
          "lib/net45/EntityFramework.SqlServer.dll": {
            "related": ".xml"
          },
          "lib/net45/EntityFramework.dll": {
            "related": ".SqlServer.xml;.xml"
          }
        },
        "runtime": {
          "lib/net45/EntityFramework.SqlServer.dll": {
            "related": ".xml"
          },
          "lib/net45/EntityFramework.dll": {
            "related": ".SqlServer.xml;.xml"
          }
        },
        "build": {
          "buildTransitive/EntityFramework.props": {},
          "buildTransitive/EntityFramework.targets": {}
        }
      },
      "Microsoft.SqlServer.Server/1.0.0": {
        "type": "package",
        "compile": {
          "lib/net46/Microsoft.SqlServer.Server.dll": {
            "related": ".pdb;.xml"
          }
        },
        "runtime": {
          "lib/net46/Microsoft.SqlServer.Server.dll": {
            "related": ".pdb;.xml"
          }
        }
      },
      "DBUtils/1.0.0": {
        "type": "project",
        "framework": ".NETFramework,Version=v4.8.1",
        "dependencies": {
          "EntityFramework": "6.5.1",
          "Microsoft.SqlServer.Server": "1.0.0"
        },
        "compile": {
          "bin/placeholder/DBUtils.dll": {}
        },
        "runtime": {
          "bin/placeholder/DBUtils.dll": {}
        }
      },
      "KlasePodataka/1.0.0": {
        "type": "project",
        "framework": ".NETFramework,Version=v4.8.1",
        "dependencies": {
          "DBUtils": "1.0.0",
          "EntityFramework": "6.5.1",
          "Microsoft.SqlServer.Server": "1.0.0"
        },
        "compile": {
          "bin/placeholder/KlasePodataka.dll": {}
        },
        "runtime": {
          "bin/placeholder/KlasePodataka.dll": {}
        }
      }
    }
  },
  "libraries": {
    "EntityFramework/6.5.1": {
      "sha512": "sQRP2lWg1i3aAGWqdliAM8zrGx7LHMUk+9/MoxUjwfTZYGMXvZ2JYZTlyTm1PqDxvn3c9E3U76TWDON7Y5+CVA==",
      "type": "package",
      "path": "entityframework/6.5.1",
      "hasTools": true,
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "Icon.png",
        "README.md",
        "build/EntityFramework.DefaultItems.props",
        "build/EntityFramework.props",
        "build/EntityFramework.targets",
        "build/Microsoft.Data.Entity.Build.Tasks.dll",
        "build/net6.0/EntityFramework.props",
        "build/net6.0/EntityFramework.targets",
        "buildTransitive/EntityFramework.props",
        "buildTransitive/EntityFramework.targets",
        "buildTransitive/net6.0/EntityFramework.props",
        "buildTransitive/net6.0/EntityFramework.targets",
        "content/net40/App.config.install.xdt",
        "content/net40/App.config.transform",
        "content/net40/Web.config.install.xdt",
        "content/net40/Web.config.transform",
        "entityframework.6.5.1.nupkg.sha512",
        "entityframework.nuspec",
        "lib/net40/EntityFramework.SqlServer.dll",
        "lib/net40/EntityFramework.SqlServer.xml",
        "lib/net40/EntityFramework.dll",
        "lib/net40/EntityFramework.xml",
        "lib/net45/EntityFramework.SqlServer.dll",
        "lib/net45/EntityFramework.SqlServer.xml",
        "lib/net45/EntityFramework.dll",
        "lib/net45/EntityFramework.xml",
        "lib/netstandard2.1/EntityFramework.SqlServer.dll",
        "lib/netstandard2.1/EntityFramework.SqlServer.xml",
        "lib/netstandard2.1/EntityFramework.dll",
        "lib/netstandard2.1/EntityFramework.xml",
        "tools/EntityFramework6.PS2.psd1",
        "tools/EntityFramework6.PS2.psm1",
        "tools/EntityFramework6.psd1",
        "tools/EntityFramework6.psm1",
        "tools/about_EntityFramework6.help.txt",
        "tools/init.ps1",
        "tools/install.ps1",
        "tools/net40/any/ef6.exe",
        "tools/net40/any/ef6.pdb",
        "tools/net40/win-arm64/ef6.exe",
        "tools/net40/win-arm64/ef6.pdb",
        "tools/net40/win-x86/ef6.exe",
        "tools/net40/win-x86/ef6.pdb",
        "tools/net45/any/ef6.exe",
        "tools/net45/any/ef6.pdb",
        "tools/net45/win-arm64/ef6.exe",
        "tools/net45/win-arm64/ef6.pdb",
        "tools/net45/win-x86/ef6.exe",
        "tools/net45/win-x86/ef6.pdb",
        "tools/net6.0/any/ef6.dll",
        "tools/net6.0/any/ef6.pdb",
        "tools/net6.0/any/ef6.runtimeconfig.json"
      ]
    },
    "Microsoft.SqlServer.Server/1.0.0": {
      "sha512": "N4KeF3cpcm1PUHym1RmakkzfkEv3GRMyofVv40uXsQhCQeglr2OHNcUk2WOG51AKpGO8ynGpo9M/kFXSzghwug==",
      "type": "package",
      "path": "microsoft.sqlserver.server/1.0.0",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "dotnet.png",
        "lib/net46/Microsoft.SqlServer.Server.dll",
        "lib/net46/Microsoft.SqlServer.Server.pdb",
        "lib/net46/Microsoft.SqlServer.Server.xml",
        "lib/netstandard2.0/Microsoft.SqlServer.Server.dll",
        "lib/netstandard2.0/Microsoft.SqlServer.Server.pdb",
        "lib/netstandard2.0/Microsoft.SqlServer.Server.xml",
        "microsoft.sqlserver.server.1.0.0.nupkg.sha512",
        "microsoft.sqlserver.server.nuspec"
      ]
    },
    "DBUtils/1.0.0": {
      "type": "project",
      "path": "../DBUtils/DBUtils.csproj",
      "msbuildProject": "../DBUtils/DBUtils.csproj"
    },
    "KlasePodataka/1.0.0": {
      "type": "project",
      "path": "../KlasePodataka/KlasePodataka.csproj",
      "msbuildProject": "../KlasePodataka/KlasePodataka.csproj"
    }
  },
  "projectFileDependencyGroups": {
    ".NETFramework,Version=v4.8.1": [
      "DBUtils >= 1.0.0",
      "EntityFramework >= 6.5.1",
      "KlasePodataka >= 1.0.0",
      "Microsoft.SqlServer.Server >= 1.0.0"
    ]
  },
  "packageFolders": {
    "C:\\Users\\Korisnik\\.nuget\\packages\\": {},
    "C:\\Program Files (x86)\\Microsoft Visual Studio\\Shared\\NuGetPackages": {}
  },
  "project": {
    "version": "1.0.0",
    "restore": {
      "projectUniqueName": "C:\\Users\\Korisnik\\source\\repos\\PrezentacionaLogika\\PrezentacionaLogika.csproj",
      "projectName": "PrezentacionaLogika",
      "projectPath": "C:\\Users\\Korisnik\\source\\repos\\PrezentacionaLogika\\PrezentacionaLogika.csproj",
      "packagesPath": "C:\\Users\\Korisnik\\.nuget\\packages\\",
      "outputPath": "C:\\Users\\Korisnik\\source\\repos\\PrezentacionaLogika\\obj\\",
      "projectStyle": "PackageReference",
      "fallbackFolders": [
        "C:\\Program Files (x86)\\Microsoft Visual Studio\\Shared\\NuGetPackages"
      ],
      "configFilePaths": [
        "C:\\Users\\Korisnik\\AppData\\Roaming\\NuGet\\NuGet.Config",
        "C:\\Program Files (x86)\\NuGet\\Config\\Microsoft.VisualStudio.FallbackLocation.config",
        "C:\\Program Files (x86)\\NuGet\\Config\\Microsoft.VisualStudio.Offline.config"
      ],
      "originalTargetFrameworks": [
        "net481"
      ],
      "sources": {
        "C:\\Program Files (x86)\\Microsoft SDKs\\NuGetPackages\\": {},
        "https://api.nuget.org/v3/index.json": {}
      },
      "frameworks": {
        "net481": {
          "targetAlias": "net481",
          "projectReferences": {
            "C:\\Users\\Korisnik\\source\\repos\\DBUtils\\DBUtils.csproj": {
              "projectPath": "C:\\Users\\Korisnik\\source\\repos\\DBUtils\\DBUtils.csproj"
            },
            "C:\\Users\\Korisnik\\source\\repos\\KlasePodataka\\KlasePodataka.csproj": {
              "projectPath": "C:\\Users\\Korisnik\\source\\repos\\KlasePodataka\\KlasePodataka.csproj"
            }
          }
        }
      },
      "warningProperties": {
        "warnAsError": [
          "NU1605"
        ]
      },
      "restoreAuditProperties": {
        "enableAudit": "true",
        "auditLevel": "low",
        "auditMode": "all"
      },
      "SdkAnalysisLevel": "9.0.100"
    },
    "frameworks": {
      "net481": {
        "targetAlias": "net481",
        "dependencies": {
          "EntityFramework": {
            "target": "Package",
            "version": "[6.5.1, )"
          },
          "Microsoft.SqlServer.Server": {
            "target": "Package",
            "version": "[1.0.0, )"
          }
        },
        "runtimeIdentifierGraphPath": "C:\\Program Files\\dotnet\\sdk\\9.0.100\\RuntimeIdentifierGraph.json"
      }
    }
  }
}