#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using db;
using db.JsonObjects;
using wServer.networking.cliPackets;
using wServer.networking.svrPackets;
using wServer.realm.entities;
using wServer.realm.entities.player;
using System.Globalization;
using wServer.realm;
using wServer.realm.worlds;
using FailurePacket = wServer.networking.svrPackets.FailurePacket;

#endregion

namespace wServer.realm.commands
{
    internal class ShowGiftCode : Command
    {
        public ShowGiftCode()
            : base("giftcode")
        {
        }

        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            var giftCode = player.Client.Account.NextGiftCode();
            if (giftCode == null)
            {
                player.SendError("No new giftcode found.");
                return false;
            }

            var data = AccountDataHelper.GenerateAccountGiftCodeData(player.AccountId, giftCode).Write();
            var qrGenerator = new QrCodeGenerator();
            var qrCode = qrGenerator.CreateQrCode($"{Program.Settings.GetValue<string>("serverDomain")}/account/redeemGiftCode?data={data}", QrCodeGenerator.EccLevel.H);
            var bmp = qrCode.GetGraphic(5);
            var rgbValues = bmp.GetPixels();

            player.Client.SendPacket(new PicPacket
            {
                BitmapData = new BitmapData
                {
                    Bytes = rgbValues,
                    Height = bmp.Height,
                    Width = bmp.Width
                }
            });
            return true;
        }
    }

    internal class LeftToMax : Command
    {
        public LeftToMax() : base("lefttomax") { }
        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            int Hp = player.ObjectDesc.MaxHitPoints - player.Stats[0];
            int Mp = player.ObjectDesc.MaxMagicPoints - player.Stats[1];
            int Atk = player.ObjectDesc.MaxAttack - player.Stats[2];
            int Def = player.ObjectDesc.MaxDefense - player.Stats[3];
            int Spd = player.ObjectDesc.MaxSpeed - player.Stats[4];
            int Vit = player.ObjectDesc.MaxHpRegen - player.Stats[5];
            int Wis = player.ObjectDesc.MaxMpRegen - player.Stats[6];
            int Dex = player.ObjectDesc.MaxDexterity - player.Stats[7];
            player.SendInfo(Hp + " HP");
            player.SendInfo(Mp + " MP");
            player.SendInfo(Atk + " ATK");
            player.SendInfo(Def + " DEF");
            player.SendInfo(Spd + " SPD");
            player.SendInfo(Vit + " VIT");
            player.SendInfo(Wis + " WIS");
            player.SendInfo(Dex + " DEX");
            return true;
        }
    }

    internal class GlandCommand : Command
    {
        public GlandCommand()
            : base("glands", 0)
        {
        }

        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            if (args.Length == 1000 || args.Length == 1000)
            {
                player.SendHelp("Usage: /glands to tp to glands");
            }
            else
            {
                int x, y;
                try
                {
                    x = int.Parse("1000");
                    y = int.Parse("1000");
                }
                catch
                {
                    player.SendError("Invalid coordinates!");
                    return false;
                }
                player.Move(x + 0.5f, y + 0.5f);
                if (player.Pet != null)
                    player.Pet.Move(x + 0.5f, y + 0.5f);
                player.UpdateCount++;
                player.Owner.BroadcastPacket(new GotoPacket
                {
                    ObjectId = player.Id,
                    Position = new Position
                    {
                        X = player.X,
                        Y = player.Y
                    }
                }, null);
            }
            return true;
        }
    }

    internal class RogueCommand : Command
    {
        public RogueCommand() : base("rogue", 0)
        {
        }
        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            for (int i = 0; i < player.Inventory.Length; i++)
            {
                player.Inventory[4] = player.Manager.GameData.Items[0xa8a]; // Agate
                player.Inventory[5] = player.Manager.GameData.Items[0xae1]; // Twlight
                player.Inventory[6] = player.Manager.GameData.Items[0xa90]; // Griffon
                player.Inventory[7] = player.Manager.GameData.Items[0xac5]; // Para HP
                player.UpdateCount++;
            }
            player.SendInfo("Set Given");
            return true;
        }
    }
    internal class ArcherCommand : Command
    {
        public ArcherCommand() : base("archer", 0)
        {
        }
        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            for (int i = 0; i < player.Inventory.Length; i++)
            {
                player.Inventory[4] = player.Manager.GameData.Items[0xa8d]; // BBow
                player.Inventory[5] = player.Manager.GameData.Items[0xa65]; // Gquiver
                player.Inventory[6] = player.Manager.GameData.Items[0xa90]; // Griffon
                player.Inventory[7] = player.Manager.GameData.Items[0xac5]; // Para HP
                player.UpdateCount++;
            }
            player.SendInfo("Set Given");
            return true;
        }
    }
    internal class WizardCommand : Command
    {
        public WizardCommand() : base("wizard", 0)
        {
        }
        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            for (int i = 0; i < player.Inventory.Length; i++)
            {
                player.Inventory[4] = player.Manager.GameData.Items[0xaa2]; // Astral
                player.Inventory[5] = player.Manager.GameData.Items[0xa30]; // MNova
                player.Inventory[6] = player.Manager.GameData.Items[0xa96]; // Elder
                player.Inventory[7] = player.Manager.GameData.Items[0xac5]; // Para HP
                player.UpdateCount++;
            }
            player.SendInfo("Set Given");
            return true;
        }
    }
    internal class PriestCommand : Command
    {
        public PriestCommand() : base("priest", 0)
        {
        }
        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            for (int i = 0; i < player.Inventory.Length; i++)
            {
                player.Inventory[4] = player.Manager.GameData.Items[0xa87]; // Ancient Warning
                player.Inventory[5] = player.Manager.GameData.Items[0xa5b]; // T5 Tome
                player.Inventory[6] = player.Manager.GameData.Items[0xa96]; // Elder
                player.Inventory[7] = player.Manager.GameData.Items[0xac5]; // Para HP
                player.UpdateCount++;
            }
            player.SendInfo("Set Given");
            return true;
        }
    }
    internal class WarriorCommand : Command
    {
        public WarriorCommand() : base("warrior", 0)
        {
        }
        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            for (int i = 0; i < player.Inventory.Length; i++)
            {
                player.Inventory[4] = player.Manager.GameData.Items[0xa47]; // Sky
                player.Inventory[5] = player.Manager.GameData.Items[0xa6b]; // Ghelm
                player.Inventory[6] = player.Manager.GameData.Items[0xa93]; // Abyssal
                player.Inventory[7] = player.Manager.GameData.Items[0xac5]; // Para HP
                player.UpdateCount++;
            }
            player.SendInfo("Set Given");
            return true;
        }
    }
    internal class KnightCommand : Command
    {
        public KnightCommand() : base("knight", 0)
        {
        }
        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            for (int i = 0; i < player.Inventory.Length; i++)
            {
                player.Inventory[4] = player.Manager.GameData.Items[0xa47]; // Sky
                player.Inventory[5] = player.Manager.GameData.Items[0xa0c]; // Mith Shield
                player.Inventory[6] = player.Manager.GameData.Items[0xa93]; // Abyssal
                player.Inventory[7] = player.Manager.GameData.Items[0xac5]; // Para HP
                player.UpdateCount++;
            }
            player.SendInfo("Set Given");
            return true;
        }
    }
    internal class PaladinCommand : Command
    {
        public PaladinCommand() : base("paladin", 0)
        {
        }
        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            for (int i = 0; i < player.Inventory.Length; i++)
            {
                player.Inventory[4] = player.Manager.GameData.Items[0xa47]; // Sky
                player.Inventory[5] = player.Manager.GameData.Items[0xa55]; // T5 Seal
                player.Inventory[6] = player.Manager.GameData.Items[0xa93]; // Abyssal
                player.Inventory[7] = player.Manager.GameData.Items[0xac5]; // Para HP
                player.UpdateCount++;
            }
            player.SendInfo("Set Given");
            return true;
        }
    }
    internal class AssassinCommand : Command
    {
        public AssassinCommand() : base("assassin", 0)
        {
        }
        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            for (int i = 0; i < player.Inventory.Length; i++)
            {
                player.Inventory[4] = player.Manager.GameData.Items[0xa8a]; // Agate
                player.Inventory[5] = player.Manager.GameData.Items[0xaa8]; // Nightwing
                player.Inventory[6] = player.Manager.GameData.Items[0xa90]; // Griffon
                player.Inventory[7] = player.Manager.GameData.Items[0xac5]; // Para HP
                player.UpdateCount++;
            }
            player.SendInfo("Set Given");
            return true;
        }
    }
    internal class NecromanserCommand : Command
    {
        public NecromanserCommand() : base("necromanser", 0)
        {
        }
        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            for (int i = 0; i < player.Inventory.Length; i++)
            {
                player.Inventory[4] = player.Manager.GameData.Items[0xaa2]; // Astral
                player.Inventory[5] = player.Manager.GameData.Items[0xaaf]; // Lifedrinker
                player.Inventory[6] = player.Manager.GameData.Items[0xa96]; // Elder
                player.Inventory[7] = player.Manager.GameData.Items[0xac5]; // Para HP
                player.UpdateCount++;
            }
            player.SendInfo("Set Given");
            return true;
        }
    }
    internal class HuntressCommand : Command
    {
        public HuntressCommand() : base("huntress", 0)
        {
        }
        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            for (int i = 0; i < player.Inventory.Length; i++)
            {
                player.Inventory[4] = player.Manager.GameData.Items[0xa8d]; // BBow
                player.Inventory[5] = player.Manager.GameData.Items[0xab6]; // Dstalker
                player.Inventory[6] = player.Manager.GameData.Items[0xa90]; // Griffon
                player.Inventory[7] = player.Manager.GameData.Items[0xac5]; // Para HP
                player.UpdateCount++;
            }
            player.SendInfo("Set Given");
            return true;
        }
    }
    internal class MysticCommand : Command
    {
        public MysticCommand() : base("mystic", 0)
        {
        }
        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            for (int i = 0; i < player.Inventory.Length; i++)
            {
                player.Inventory[4] = player.Manager.GameData.Items[0xaa2]; // Astral
                player.Inventory[5] = player.Manager.GameData.Items[0xa46]; // Banishment Orb
                player.Inventory[6] = player.Manager.GameData.Items[0xa96]; // Elder
                player.Inventory[7] = player.Manager.GameData.Items[0xac5]; // Para HP
                player.UpdateCount++;
            }
            player.SendInfo("Set Given");
            return true;
        }
    }
    internal class TricksterCommand : Command
    {
        public TricksterCommand() : base("trickster", 0)
        {
        }
        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            for (int i = 0; i < player.Inventory.Length; i++)
            {
                player.Inventory[4] = player.Manager.GameData.Items[0xa8a]; // Agate
                player.Inventory[5] = player.Manager.GameData.Items[0xb20]; // Phantoms
                player.Inventory[6] = player.Manager.GameData.Items[0xa90]; // Griffon
                player.Inventory[7] = player.Manager.GameData.Items[0xac5]; // Para HP
                player.UpdateCount++;
            }
            player.SendInfo("Set Given");
            return true;
        }
    }
    internal class SorcererCommand : Command
    {
        public SorcererCommand() : base("Sorcerer", 0)
        {
        }
        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            for (int i = 0; i < player.Inventory.Length; i++)
            {
                player.Inventory[4] = player.Manager.GameData.Items[0xa87]; // Ancient Warning
                player.Inventory[5] = player.Manager.GameData.Items[0xb32]; // Skybolt
                player.Inventory[6] = player.Manager.GameData.Items[0xa96]; // Elder
                player.Inventory[7] = player.Manager.GameData.Items[0xac5]; // Para HP
                player.UpdateCount++;
            }
            player.SendInfo("Set Given");
            return true;
        }
    }
    internal class NinjaCommand : Command
    {
        public NinjaCommand() : base("ninja", 0)
        {
        }
        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            for (int i = 0; i < player.Inventory.Length; i++)
            {
                player.Inventory[4] = player.Manager.GameData.Items[0xc4f]; // Muramasa
                player.Inventory[5] = player.Manager.GameData.Items[0xc58]; // Ice Star
                player.Inventory[6] = player.Manager.GameData.Items[0xa90]; // Griffon
                player.Inventory[7] = player.Manager.GameData.Items[0xac5]; // Para HP
                player.UpdateCount++;
            }
            player.SendInfo("Set Given");
            return true;
        }
    }
    internal class SuicideCommand : Command
    {
        public SuicideCommand()
            : base("nuce")
        {
        }

        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            player.HP = 0;
            player.Death("Rope"); //what is will say has killed you
            return true;
        }
    }
    internal class TutorialCommand : Command
    {
        public TutorialCommand()
            : base("tutorial")
        {
        }

        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            player.Client.Reconnect(new ReconnectPacket
            {
                Host = "",
                Port = Program.Settings.GetValue<int>("port"),
                GameId = World.TUT_ID,
                Name = "Tutorial",
                Key = Empty<byte>.Array,
            });
            return true;
        }
    }
    internal class TradeCommand : Command
    {
        public TradeCommand()
            : base("trade")
        {
        }

        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            if(String.IsNullOrWhiteSpace(args[0]))
            {
                player.SendInfo("Usage: /trade <player name>");
                return false;
            }
            player.RequestTrade(time, new RequestTradePacket
            {
                Name = args[0]
            });
            return true;
        }
    }


    internal class WhoCommand : Command
    {
        public WhoCommand()
            : base("who")
        {
        }

        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            StringBuilder sb = new StringBuilder("Players online: ");
            Player[] copy = player.Owner.Players.Values.ToArray();
            for (int i = 0; i < copy.Length; i++)
            {
                if (i != 0) sb.Append(", ");
                sb.Append(copy[i].Name);
            }

            player.SendInfo(sb.ToString());
            return true;
        }
    }

    internal class ServerCommand : Command
    {
        public ServerCommand()
            : base("server")
        {
        }

        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            player.SendInfo(player.Owner.Name);
            return true;
        }
    }

    internal class PauseCommand : Command
    {
        public PauseCommand()
            : base("pause")
        {
        }

        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            if (player.HasConditionEffect(ConditionEffectIndex.Paused))
            {
                player.ApplyConditionEffect(new ConditionEffect
                {
                    Effect = ConditionEffectIndex.Paused,
                    DurationMS = 0
                });
                player.SendInfo("Game resumed.");
            }
            else
            {
                foreach (Enemy i in player.Owner.EnemiesCollision.HitTest(player.X, player.Y, 8).OfType<Enemy>())
                {
                    if (i.ObjectDesc.Enemy)
                    {
                        player.SendInfo("Not safe to pause.");
                        return false;
                    }
                }
                player.ApplyConditionEffect(new ConditionEffect
                {
                    Effect = ConditionEffectIndex.Paused,
                    DurationMS = -1
                });
                player.SendInfo("Game paused.");
            }
            return true;
        }
    }

    internal class TeleportCommand : Command
    {
        public TeleportCommand()
            : base("teleport")
        {
        }

        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            try
            {
                if (String.Equals(player.Name.ToLower(), args[0].ToLower()))
                {
                    player.SendInfo("You are already at yourself, and always will be!");
                    return false;
                }

                foreach (KeyValuePair<int, Player> i in player.Owner.Players)
                {
                    if (i.Value.Name.ToLower() == args[0].ToLower().Trim())
                    {
                        player.Teleport(time, new TeleportPacket
                        {
                            ObjectId = i.Value.Id
                        });
                        return true;
                    }
                }
                player.SendInfo(string.Format("Cannot teleport, {0} not found!", args[0].Trim()));
            }
            catch
            {
                player.SendHelp("Usage: /teleport <player name>");
            }
            return false;
        }
    }

    class TellCommand : Command
    {
        public TellCommand() : base("tell") { }

        protected override bool Process(Player player, RealmTime time, string[] args)
        {
            if (!player.NameChosen)
            {
                player.SendError("Choose a name!");
                return false;
            }
            if (args.Length < 2)
            {
                player.SendError("Usage: /tell <player name> <text>");
                return false;
            }

            string playername = args[0].Trim();
            string msg = string.Join(" ", args, 1, args.Length - 1);

            if (String.Equals(player.Name.ToLower(), playername.ToLower()))
            {
                player.SendInfo("Quit telling yourself!");
                return false;
            }

            if (playername.ToLower() == "muledump")
            {
                if (msg.ToLower() == "private muledump")
                {
                    player.Client.SendPacket(new TextPacket() //echo to self
                    {
                        ObjectId = player.Id,
                        BubbleTime = 10,
                        Stars = player.Stars,
                        Name = player.Name,
                        Recipient = "Muledump",
                        Text = msg.ToSafeText(),
                        CleanText = ""
                    });

                    player.Manager.Database.DoActionAsync(db =>
                    {
                        var cmd = db.CreateQuery();
                        cmd.CommandText = "UPDATE accounts SET publicMuledump=0 WHERE id=@accId;";
                        cmd.Parameters.AddWithValue("@accId", player.AccountId);
                        cmd.ExecuteNonQuery();
                        player.Client.SendPacket(new TextPacket()
                        {
                            ObjectId = -1,
                            BubbleTime = 10,
                            Stars = 70,
                            Name = "Muledump",
                            Recipient = player.Name,
                            Text = "Your muledump is now hidden, only you can view it now.",
                            CleanText = ""
                        });
                    });
                }
                else if (msg.ToLower() == "public muledump")
                {
                    player.Client.SendPacket(new TextPacket() //echo to self
                    {
                        ObjectId = player.Id,
                        BubbleTime = 10,
                        Stars = player.Stars,
                        Name = player.Name,
                        Recipient = "Muledump",
                        Text = msg.ToSafeText(),
                        CleanText = ""
                    });
                    player.Manager.Database.DoActionAsync(db =>
                    {
                        var cmd = db.CreateQuery();
                        cmd.CommandText = "UPDATE accounts SET publicMuledump=1 WHERE id=@accId;";
                        cmd.Parameters.AddWithValue("@accId", player.AccountId);
                        cmd.ExecuteNonQuery();

                        player.Client.SendPacket(new TextPacket()
                        {
                            ObjectId = -1,
                            BubbleTime = 10,
                            Stars = 70,
                            Name = "Muledump",
                            Recipient = player.Name,
                            Text = "Your muledump is now public, anyone can view it now.",
                            CleanText = ""
                        });
                    });
                }
                else
                {
                    player.Client.SendPacket(new TextPacket() //echo to self
                    {
                        ObjectId = player.Id,
                        BubbleTime = 10,
                        Stars = player.Stars,
                        Name = player.Name,
                        Recipient = "Muledump",
                        Text = msg.ToSafeText(),
                        CleanText = ""
                    });

                    player.Client.SendPacket(new TextPacket()
                    {
                        ObjectId = -1,
                        BubbleTime = 10,
                        Stars = 70,
                        Name = "Muledump",
                        Recipient = player.Name,
                        Text = "U WOT M8, 1v1 IN THE GARAGE!!!!111111oneoneoneeleven",
                        CleanText = ""
                    });
                }
                return true;
            }

            foreach (var i in player.Manager.Clients.Values)
            {
                if (i.Account.NameChosen && i.Account.Name.EqualsIgnoreCase(playername))
                {
                    player.Client.SendPacket(new TextPacket() //echo to self
                    {
                        ObjectId = player.Id,
                        BubbleTime = 10,
                        Stars = player.Stars,
                        Name = player.Name,
                        Recipient = i.Account.Name,
                        Text = msg.ToSafeText(),
                        CleanText = ""
                    });

                    i.SendPacket(new TextPacket() //echo to /tell player
                    {
                        ObjectId = i.Player.Owner.Id == player.Owner.Id ? player.Id : -1,
                        BubbleTime = 10,
                        Stars = player.Stars,
                        Name = player.Name,
                        Recipient = i.Account.Name,
                        Text = msg.ToSafeText(),
                        CleanText = ""
                    });
                    return true;
                }
            }
            player.SendError(string.Format("{0} not found.", playername));
            return false;
        }
    }
}