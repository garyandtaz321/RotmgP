#region

using db;
using MySql.Data.MySqlClient;
using System;
using System.Text;

#endregion

namespace server.arena
{
    internal class getRecords : RequestHandler
    {
        protected override void HandleRequest()
        {
            string result = "";
            using (Database dbx = new Database())
            {
                Account acc = dbx.Verify(Query["guid"], Query["password"], Program.GameData);
                if (String.IsNullOrEmpty(Query["guid"]) ||
                    String.IsNullOrEmpty(Query["password"]) ||
                    String.IsNullOrEmpty(Query["type"]) ||
                    acc == null)
                {
                    Context.Response.StatusCode = 400;
                    result = "<Error>Invalid GUID/password combination</Error>";
                }
                else
                {
                    string[][] ranks = dbx.GetArenaLeaderboards(Query["type"], acc);
                    result += "<ArenaRecords>";
                    foreach (string[] i in ranks)
                    {
                        MySqlCommand cmd = dbx.CreateQuery();
                        cmd.CommandText = "select skin, tex1, tex2, items, charType, petId from characters where charid = @charid";
                        cmd.Parameters.AddWithValue("@charid", i[2]);
                        string skin, tex1, tex2, inventory, cclass, petid;
                        skin = tex1 = tex2 = inventory = cclass = petid = null;
                        using (MySqlDataReader drdr = cmd.ExecuteReader())
                        {
                            while (drdr.Read())
                            {
                                skin = drdr.GetString("skin");
                                tex1 = drdr.GetString("tex1");
                                tex2 = drdr.GetString("tex2");
                                inventory = drdr.GetString("items");
                                cclass = drdr.GetString("charType");
                                petid = drdr.GetString("petId");
                            }
                        }

                        var _pet = dbx.GetPet(int.Parse(petid), acc);
                        result += $"<Record><WaveNumber>{i[0]}</WaveNumber><Time>{i[4]}</Time><PlayData><CharacterData>";
                        if (acc.Guild.Name != null) result += $@"<GuildName>{acc.Guild.Name}</GuildName><GuildRank>{acc.Guild.Rank}</GuildRank>";
                        result += $"<Id>{i[2]}</Id><Texture>{skin}</Texture><Tex1>{tex1}</Tex1><Tex2>{tex2}</Tex2><Inventory>{inventory}</Inventory><Name>{acc.Name}</Name><Class>{cclass}</Class></CharacterData>";
                        result += "<Pet name=\"" + _pet.SkinName + "\" type=\"" + _pet.Type + "\" instanceId=\"" + _pet.InstanceId + "\" rarity=\"" + _pet.Rarity + "\" maxAbilityPower=\"" + _pet.MaxAbilityPower + "\" skin=\"" + _pet.Skin + "\" family=\"" + "Farm" + "\"><Abilities>";
                        for (int e = 0; e < 3; e++)
                            result += "<Ability type=\"" + _pet.Abilities[e].Type + "\" power=\"" + _pet.Abilities[e].Power + "\" points=\"" + _pet.Abilities[e].Points + "\"/>";
                        result += "</Abilities></Pet></PlayData></Record>";
                    }
                    result += "</ArenaRecords>";
                }
            }
            byte[] buf = Encoding.UTF8.GetBytes(result);
            Context.Response.ContentType = "text/*";
            Context.Response.OutputStream.Write(buf, 0, buf.Length);
        }
    }
}
