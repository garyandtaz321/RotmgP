#region

using System;
using System.Collections.Generic;
using System.Linq;
using db.data;
using log4net;

#endregion

namespace wServer.realm.entities
{
    internal class MerchantLists
    {
        public static int[] AccessoryClothList;
        public static int[] AccessoryDyeList;
        public static int[] ClothingClothList;
        public static int[] ClothingDyeList;

        public static Dictionary<int, Tuple<int, CurrencyType>> prices = new Dictionary<int, Tuple<int, CurrencyType>>
        {
            {0xb41, new Tuple<int, CurrencyType>(0, CurrencyType.Fame)},
            {0xbab, new Tuple<int, CurrencyType>(0, CurrencyType.Fame)},
            {0xbad, new Tuple<int, CurrencyType>(0, CurrencyType.Fame)},

            //WEAPONS
            {0xaf6, new Tuple<int, CurrencyType>(900, CurrencyType.Fame)}, //Wand Of Recompense T12
            {0xa87, new Tuple<int, CurrencyType>(450, CurrencyType.Fame)}, //Wand Of Ancient Warning T11
            {0xa86, new Tuple<int, CurrencyType>(250, CurrencyType.Fame)}, //Wand Of Shadow T10
            {0xa85, new Tuple<int, CurrencyType>(100, CurrencyType.Fame)}, //Wand Of Deep Sorcery T9
            {0xa07, new Tuple<int, CurrencyType>(51, CurrencyType.Fame)}, //Wand Of Death T8
            {0xb02, new Tuple<int, CurrencyType>(900, CurrencyType.Fame)}, //Bow Of Covert Havens T12
            {0xa8d, new Tuple<int, CurrencyType>(450, CurrencyType.Fame)}, //Bow Of Innocent Blood T11
            {0xa8c, new Tuple<int, CurrencyType>(250, CurrencyType.Fame)}, //Bow Of Fey Magic T10
            {0xa8b, new Tuple<int, CurrencyType>(100, CurrencyType.Fame)}, //Verdant Bow T9
            {0xa1e, new Tuple<int, CurrencyType>(51, CurrencyType.Fame)}, //Golden Bow T8
            {0xb08, new Tuple<int, CurrencyType>(900, CurrencyType.Fame)}, //Staff of the Cosmic Whole T12
            {0xaa2, new Tuple<int, CurrencyType>(450, CurrencyType.Fame)}, //Staff of Astral Knowledge T11
            {0xaa1, new Tuple<int, CurrencyType>(250, CurrencyType.Fame)}, //Staff of Diabolic Secrets T10
            {0xaa0, new Tuple<int, CurrencyType>(100, CurrencyType.Fame)}, //Staff Of Necrotic Arcana T9
            {0xa9f, new Tuple<int, CurrencyType>(51, CurrencyType.Fame)}, //Staff of Horror T8
            {0xb0b, new Tuple<int, CurrencyType>(900, CurrencyType.Fame)}, //Sword of Acclaim T12
            {0xa47, new Tuple<int, CurrencyType>(450, CurrencyType.Fame)}, //Skysplitter Sword T11
            {0xa84, new Tuple<int, CurrencyType>(250, CurrencyType.Fame)}, //Archon Sword T10
            {0xa83, new Tuple<int, CurrencyType>(100, CurrencyType.Fame)}, //Dragonsoul Sword T9
            {0xa82, new Tuple<int, CurrencyType>(51, CurrencyType.Fame)}, //Ravenheart Sword T8
            {0xaff, new Tuple<int, CurrencyType>(900, CurrencyType.Fame)}, //Dagger Of Foul Malevolence T12
            {0xa8a, new Tuple<int, CurrencyType>(450, CurrencyType.Fame)}, //Agateclaw Dagger T11
            {0xa89, new Tuple<int, CurrencyType>(250, CurrencyType.Fame)}, //Emeraldshard Dagger T10
            {0xa88, new Tuple<int, CurrencyType>(100, CurrencyType.Fame)}, //Ragetalon Dagger T9
            {0xa19, new Tuple<int, CurrencyType>(51, CurrencyType.Fame)}, //Fire Dagger T8
            {0xc50, new Tuple<int, CurrencyType>(850, CurrencyType.Fame)}, //Masamune T12
            {0xc4f, new Tuple<int, CurrencyType>(450, CurrencyType.Fame)}, //Muramasa T11
            {0xc4e, new Tuple<int, CurrencyType>(250, CurrencyType.Fame)}, //Ichimonji T10
            {0xc4d, new Tuple<int, CurrencyType>(100, CurrencyType.Fame)}, //Jewel Eye Katana T9
            {0xc4c, new Tuple<int, CurrencyType>(51, CurrencyType.Fame)}, //Demon Edge T8

            //Rings
            {0xabf, new Tuple<int, CurrencyType>(100, CurrencyType.Fame)}, //Ring of Paramount Attack T4
            {0xac0, new Tuple<int, CurrencyType>(120, CurrencyType.Fame)}, //Ring of Paramount Defense T4
            {0xac1, new Tuple<int, CurrencyType>(100, CurrencyType.Fame)}, //Ring Of Paramount Speed T4
            {0xac2, new Tuple<int, CurrencyType>(100, CurrencyType.Fame)}, //Ring Of Paramount Vitality T4
            {0xac3, new Tuple<int, CurrencyType>(100, CurrencyType.Fame)}, //Ring Of Paramount Wisdom T4
            {0xac4, new Tuple<int, CurrencyType>(100, CurrencyType.Fame)}, //Ring Of Paramount Dexterity T4
            {0xac5, new Tuple<int, CurrencyType>(120, CurrencyType.Fame)}, //Ring Of Paramount Health T4
            {0xac6, new Tuple<int, CurrencyType>(120, CurrencyType.Fame)}, //Ring Of Paramount Magic T4
            {0xac7, new Tuple<int, CurrencyType>(200, CurrencyType.Fame)}, //Ring Of Exalted Attack T5
            {0xac8, new Tuple<int, CurrencyType>(400, CurrencyType.Fame)}, //Ring Of Exalted Defense T5
            {0xac9, new Tuple<int, CurrencyType>(200, CurrencyType.Fame)}, //Ring Of Exalted Speed T5
            {0xaca, new Tuple<int, CurrencyType>(200, CurrencyType.Fame)}, //Ring Of Exalted Vitality T5
            {0xacb, new Tuple<int, CurrencyType>(200, CurrencyType.Fame)}, //Ring Of Exalted Wisdom T5
            {0xacc, new Tuple<int, CurrencyType>(200, CurrencyType.Fame)}, //Ring Of Exalted Dexterity T5
            {0xacd, new Tuple<int, CurrencyType>(400, CurrencyType.Fame)}, //Ring Of Exalted Health T5
            {0xace, new Tuple<int, CurrencyType>(400, CurrencyType.Fame)}, //Ring Of Exalted Magic T5
            //ARMORS
            {0xb05, new Tuple<int, CurrencyType>(900, CurrencyType.Fame)}, //Robe of the Grand Sorcerer
            {0xa96, new Tuple<int, CurrencyType>(425, CurrencyType.Fame)}, //Robe of the Elder Warlock T12
            {0xa95, new Tuple<int, CurrencyType>(250, CurrencyType.Fame)}, //Robe of the Moon Wizard T11
            {0xa94, new Tuple<int, CurrencyType>(100, CurrencyType.Fame)}, //Robe of the Shadow Magus T10
            {0xa60, new Tuple<int, CurrencyType>(51, CurrencyType.Fame)}, //Robe of the Master T9
            {0xafc, new Tuple<int, CurrencyType>(900, CurrencyType.Fame)}, //Acropolis Armor T13
            {0xa93, new Tuple<int, CurrencyType>(450, CurrencyType.Fame)}, //Abyssal Armor T12
            {0xa92, new Tuple<int, CurrencyType>(250, CurrencyType.Fame)}, //Vengeance Armor T11
            {0xa91, new Tuple<int, CurrencyType>(100, CurrencyType.Fame)}, //Desolation Armor T10
            {0xa13, new Tuple<int, CurrencyType>(51, CurrencyType.Fame)}, //Dragonscale Armor T9
            {0xaf9, new Tuple<int, CurrencyType>(900, CurrencyType.Fame)}, //Hydra Skin Armor T13
            {0xa90, new Tuple<int, CurrencyType>(450, CurrencyType.Fame)}, //Griffon Hide Armor T12
            {0xa8f, new Tuple<int, CurrencyType>(250, CurrencyType.Fame)}, //Hippogriff Hide Armor t11
            {0xa8e, new Tuple<int, CurrencyType>(100, CurrencyType.Fame)}, //Roc Leather Armor T10
            {0xad3, new Tuple<int, CurrencyType>(51, CurrencyType.Fame)}, //Drake Hide Armor T9
     
            //ABILITIES
            {0xb25, new Tuple<int, CurrencyType>(400, CurrencyType.Fame)}, //Tome Of Holy Guidance T6
            {0xa5b, new Tuple<int, CurrencyType>(175, CurrencyType.Fame)}, //Tome of Divine Favor T5
            {0xb22, new Tuple<int, CurrencyType>(400, CurrencyType.Fame)}, //Colossus Shield T6
            {0xa0c, new Tuple<int, CurrencyType>(175, CurrencyType.Fame)}, //Mithril Shield T5
            {0xb24, new Tuple<int, CurrencyType>(400, CurrencyType.Fame)}, //Elemental Detonation Spell T6
            {0xa30, new Tuple<int, CurrencyType>(175, CurrencyType.Fame)}, //Magic Nova Spell T5
            {0xb26, new Tuple<int, CurrencyType>(400, CurrencyType.Fame)}, //Seal of the Blessed Champion T6
            {0xa55, new Tuple<int, CurrencyType>(175, CurrencyType.Fame)}, //Seal of the Holy Warrior T5
            {0xb27, new Tuple<int, CurrencyType>(400, CurrencyType.Fame)}, //Cloak of Ghostly Concealment T6
            {0xae1, new Tuple<int, CurrencyType>(175, CurrencyType.Fame)}, //Cloak of Endless Twilight T5
            {0xb28, new Tuple<int, CurrencyType>(400, CurrencyType.Fame)}, //Quiver of Elvish Mastery T6
            {0xa65, new Tuple<int, CurrencyType>(175, CurrencyType.Fame)}, //Golden Quiver T5
            {0xb29, new Tuple<int, CurrencyType>(400, CurrencyType.Fame)}, //Helm of the Great General T6
            {0xa6b, new Tuple<int, CurrencyType>(175, CurrencyType.Fame)}, //Golden Helm T5
            {0xb2a, new Tuple<int, CurrencyType>(400, CurrencyType.Fame)}, //Baneserpent Poison T6
            {0xaa8, new Tuple<int, CurrencyType>(175, CurrencyType.Fame)}, //NightWing Venom T5
            {0xb2b, new Tuple<int, CurrencyType>(400, CurrencyType.Fame)}, //Bloodsucker Skull T6
            {0xaaf, new Tuple<int, CurrencyType>(175, CurrencyType.Fame)}, //Lifedrinker Skull T5
            {0xb2c, new Tuple<int, CurrencyType>(400, CurrencyType.Fame)}, //Giantcatcher Trap T6
            {0xab6, new Tuple<int, CurrencyType>(175, CurrencyType.Fame)}, //Dragonstalker Trap T5
            {0xb2d, new Tuple<int, CurrencyType>(400, CurrencyType.Fame)}, //Planefetter Orb T6
            {0xa46, new Tuple<int, CurrencyType>(175, CurrencyType.Fame)}, //Banishment Orb T5
            {0xb23, new Tuple<int, CurrencyType>(400, CurrencyType.Fame)}, //Prism of Apparitions T6
            {0xb20, new Tuple<int, CurrencyType>(175, CurrencyType.Fame)}, //Prism of Phantoms T5
            {0xb33, new Tuple<int, CurrencyType>(400, CurrencyType.Fame)}, //Scepter of Storms T6
            {0xb32, new Tuple<int, CurrencyType>(175, CurrencyType.Fame)}, //Scepter of Skybolts T5
            {0xc59, new Tuple<int, CurrencyType>(400, CurrencyType.Fame)}, //Doom Circle T6
            {0xc58, new Tuple<int, CurrencyType>(175, CurrencyType.Fame)}, //Ice Star T5

            //PET FOOD
            {0xccc, new Tuple<int, CurrencyType>(5000, CurrencyType.Fame)}, //Ambrosia 
            {0xccb, new Tuple<int, CurrencyType>(60, CurrencyType.Fame)}, //Fries
            {0xcca, new Tuple<int, CurrencyType>(360, CurrencyType.Fame)}, //Grapes Of Wrath
            {0xcc9, new Tuple<int, CurrencyType>(20, CurrencyType.Fame)}, //Soft Drink
            {0xcc8, new Tuple<int, CurrencyType>(420, CurrencyType.Fame)}, //Superburger
            {0xcc7, new Tuple<int, CurrencyType>(720, CurrencyType.Fame)}, //Double Cheese Burger Deluxe
            {0xcc6, new Tuple<int, CurrencyType>(120, CurrencyType.Fame)}, //Great Taco
            {0xcc5, new Tuple<int, CurrencyType>(180, CurrencyType.Fame)}, //Power Pizza
            {0xcc4, new Tuple<int, CurrencyType>(240, CurrencyType.Fame)}, //Chocolate Ice Cream Cookie

            //EGGS
            {0xc86, new Tuple<int, CurrencyType>(800, CurrencyType.Gold)}, //uncommon feline egg
            {0xc87, new Tuple<int, CurrencyType>(1200, CurrencyType.Gold)}, //rare feline egg
            {0xc8a, new Tuple<int, CurrencyType>(800, CurrencyType.Gold)}, //uncommon canine egg
            {0xc8b, new Tuple<int, CurrencyType>(1200, CurrencyType.Gold)}, //rare canine egg
            {0xc8e, new Tuple<int, CurrencyType>(800, CurrencyType.Gold)}, //uncommon avian egg
            {0xc8f, new Tuple<int, CurrencyType>(1200, CurrencyType.Gold)}, //rare avian egg
            {0xc92, new Tuple<int, CurrencyType>(800, CurrencyType.Gold)}, //uncommon exotic egg
            {0xc93, new Tuple<int, CurrencyType>(1200, CurrencyType.Gold)}, //rare exotic egg
            {0xc96, new Tuple<int, CurrencyType>(800, CurrencyType.Gold)}, //uncommon farm egg
            {0xc97, new Tuple<int, CurrencyType>(1200, CurrencyType.Gold)}, //rare farm egg
            {0xc9a, new Tuple<int, CurrencyType>(800, CurrencyType.Gold)}, //uncommon woodland egg
            {0xc9b, new Tuple<int, CurrencyType>(1200, CurrencyType.Gold)}, //rare woodland egg
            {0xc9e, new Tuple<int, CurrencyType>(800, CurrencyType.Gold)}, //uncommon reptile egg
            {0xc9f, new Tuple<int, CurrencyType>(1200, CurrencyType.Gold)}, //rare reptile egg
            {0xca2, new Tuple<int, CurrencyType>(800, CurrencyType.Gold)}, //uncommon insect egg
            {0xca3, new Tuple<int, CurrencyType>(1200, CurrencyType.Gold)}, //rare insect egg
            {0xca6, new Tuple<int, CurrencyType>(800, CurrencyType.Gold)}, //uncommon pinguin egg
            {0xca7, new Tuple<int, CurrencyType>(1200, CurrencyType.Gold)}, //rare pinguin egg
            {0xcaa, new Tuple<int, CurrencyType>(800, CurrencyType.Gold)}, //uncommon aquatic egg
            {0xcab, new Tuple<int, CurrencyType>(1200, CurrencyType.Gold)}, //rare aquatic egg
            {0xcae, new Tuple<int, CurrencyType>(800, CurrencyType.Gold)}, //uncommon spooky egg
            {0xcaf, new Tuple<int, CurrencyType>(1200, CurrencyType.Gold)}, //rare spooky egg
            {0xcb2, new Tuple<int, CurrencyType>(800, CurrencyType.Gold)}, //uncommon humanoid egg
            {0xcb3, new Tuple<int, CurrencyType>(1200, CurrencyType.Gold)}, //rare humanoid egg
            {0xcb6, new Tuple<int, CurrencyType>(800, CurrencyType.Gold)}, //uncommon ???? egg
            {0xcb7, new Tuple<int, CurrencyType>(1200, CurrencyType.Gold)}, //rare ???? egg
            {0xcba, new Tuple<int, CurrencyType>(800, CurrencyType.Gold)}, //uncommon automaton egg
            {0xcbb, new Tuple<int, CurrencyType>(1200, CurrencyType.Gold)}, //rare automaton egg
            {0xcbe, new Tuple<int, CurrencyType>(800, CurrencyType.Gold)}, //uncommon mystery egg
            {0xcbf, new Tuple<int, CurrencyType>(1200, CurrencyType.Gold)}, //rare mystery egg
            {0xcc0, new Tuple<int, CurrencyType>(3600, CurrencyType.Gold)}, //Legendary mystery egg
            {0xc6c, new Tuple<int, CurrencyType>(400, CurrencyType.Gold)}, //backpack

            //KEYS
            {0x2290, new Tuple<int, CurrencyType>(200, CurrencyType.Fame)}, //Bella's Key - just temporary for testing

            {0x701, new Tuple<int, CurrencyType>(75, CurrencyType.Fame)}, //Undead Lair Key
            {0x705, new Tuple<int, CurrencyType>(50, CurrencyType.Fame)}, //Pirate Cave Key
            {0x70a, new Tuple<int, CurrencyType>(75, CurrencyType.Fame)}, //Abyss of Demons Key
            {0x70b, new Tuple<int, CurrencyType>(50, CurrencyType.Fame)}, //Snake Pit Key
            {0x710, new Tuple<int, CurrencyType>(100, CurrencyType.Fame)}, //Tomb of the Ancients Key
            {0x71f, new Tuple<int, CurrencyType>(75, CurrencyType.Fame)}, //Sprite World Key
            {0xc11, new Tuple<int, CurrencyType>(100, CurrencyType.Fame)}, //Ocean Trench Key
            {0xc19, new Tuple<int, CurrencyType>(75, CurrencyType.Fame)}, //Totem Key
            {0xc23, new Tuple<int, CurrencyType>(100, CurrencyType.Fame)}, //Manor Key
            {0xc2e, new Tuple<int, CurrencyType>(100, CurrencyType.Fame)}, //Davy's Key
            {0xc2f, new Tuple<int, CurrencyType>(100, CurrencyType.Fame)}, //Lab Key
            {0xcce, new Tuple<int, CurrencyType>(125, CurrencyType.Fame)}, //Deadwater Docks Key
            {0xccf, new Tuple<int, CurrencyType>(125, CurrencyType.Fame)}, //Woodland Labyrinth Key
            {0xcda, new Tuple<int, CurrencyType>(125, CurrencyType.Fame)}, //The Crawling Depths Key
            {0xcdd, new Tuple<int, CurrencyType>(250, CurrencyType.Fame)},//Shatters Key
        };

        public static int[] store10List = { 0xb41, 0xbab, 0xbad, 0xbac };
        public static int[] store11List = { 0xb41, 0xbab, 0xbad, 0xbac };
        public static int[] store12List = { 0xb41, 0xbab, 0xbad, 0xbac };
        public static int[] store13List = { 0xb41, 0xbab, 0xbad, 0xbac };
        public static int[] store14List = { 0xb41, 0xbab, 0xbad, 0xbac };
        public static int[] store15List = { 0xb41, 0xbab, 0xbad, 0xbac };
        public static int[] store16List = { 0xb41, 0xbab, 0xbad, 0xbac };
        public static int[] store17List = { 0xb41, 0xbab, 0xbad, 0xbac };
        public static int[] store18List = { 0xb41, 0xbab, 0xbad, 0xbac };
        public static int[] store19List = { 0xb41, 0xbab, 0xbad, 0xbac };

        public static int[] store1List =
        {
            0xcdd, 0xcda, 0xccf, 0xcce, 0xc2f, 0xc2e, 0xc23, 0xc19, 0xc11, 0x71f, 0x710,
            0x70b, 0x70a, 0x705, 0x701, 0x2290
        };

        public static int[] store20List = { 0xb41, 0xbab, 0xbad, 0xbac };

        //keys need to add etcetc
        public static int[] store2List =
        {
            0xcbf, 0xcbe, 0xcbb, 0xcba, 0xcb7, 0xcb6, 0xcb2, 0xcb3, 0xcae, 0xcaf, 0xcab,
            0xcaa, 0xca7, 0xca6, 0xca3, 0xca2, 0xc9f, 0xc9e, 0xc9b, 0xc9a, 0xc97, 0xc96, 0xc93, 0xc92, 0xc8f, 0xc8e,
            0xc8b, 0xc8a, 0xc87, 0xc86, 0xcc0, 0xc6c,
        };

        //pet eggs
        public static int[] store3List = { 0xccc, 0xccb, 0xcca, 0xcc9, 0xcc8, 0xcc7, 0xcc6, 0xcc5, 0xc6c, 0xcc4 };

        //pet food
        public static int[] store4List =
        {
            0xb25, 0xa5b, 0xb22, 0xa0c, 0xb24, 0xa30, 0xb26, 0xa55, 0xb27, 0xae1, 0xb28,
            0xa65, 0xb29, 0xa6b, 0xb2a, 0xaa8, 0xb2b, 0xaaf, 0xb2c, 0xab6, 0xb2d, 0xa46, 0xb23, 0xb20, 0xb33, 0xb32,
            0xc59, 0xc58
        };

        //abilities
        public static int[] store5List =
        {
            0xb05, 0xa96, 0xa95, 0xa94, 0xa60, 0xafc, 0xa93, 0xa92, 0xa91, 0xa13, 0xaf9,
            0xa90, 0xa8f, 0xa8e, 0xad3
        };

        //armors
        public static int[] store6List =
        {
            0xaf6, 0xa87, 0xa86, 0xa85, 0xa07, 0xb02, 0xa8d, 0xa8c, 0xa8b, 0xa1e, 0xb08,
            0xaa2, 0xaa1, 0xaa0, 0xa9f
        };

        //Wands&staves&bows
        public static int[] store7List =
        {
            0xb0b, 0xa47, 0xa84, 0xa83, 0xa82, 0xaff, 0xa8a, 0xa89, 0xa88, 0xa19, 0xc50,
            0xc4f, 0xc4e, 0xc4d, 0xc4c
        };

        //Swords&daggers&samurai shit
        public static int[] store8List =
        {
            0xabf, 0xac0, 0xac1, 0xac2, 0xac3, 0xac4, 0xac5, 0xac6, 0xac7, 0xac8, 0xac9,
            0xaca, 0xacb, 0xacc, 0xacd, 0xace
        };

        // rings
        public static int[] store9List = { 0xb41, 0xbab, 0xbad, 0xbac, 0x716c, 0x2299, 0x2360, 0x21a9, 0x108e, 0xc03, 0x229e, 0xcbde };

        private static readonly ILog log = LogManager.GetLogger(typeof(MerchantLists));

        public static void InitMerchatLists(XmlData data)
        {
            log.Info("Loading merchant lists...");
            List<int> accessoryDyeList = new List<int>();
            List<int> clothingDyeList = new List<int>();
            List<int> accessoryClothList = new List<int>();
            List<int> clothingClothList = new List<int>();

            foreach (KeyValuePair<ushort, Item> item in data.Items.Where(_ => noShopCloths.All(i => i != _.Value.ObjectId)))
            {
                if (item.Value.Texture1 != 0 && item.Value.ObjectId.Contains("Clothing") && item.Value.Class == "Dye")
                {
                    prices.Add(item.Value.ObjectType, new Tuple<int, CurrencyType>(51, CurrencyType.Fame));
                    clothingDyeList.Add(item.Value.ObjectType);
                }

                if (item.Value.Texture2 != 0 && item.Value.ObjectId.Contains("Accessory") && item.Value.Class == "Dye")
                {
                    prices.Add(item.Value.ObjectType, new Tuple<int, CurrencyType>(51, CurrencyType.Fame));
                    accessoryDyeList.Add(item.Value.ObjectType);
                }

                if (item.Value.Texture1 != 0 && item.Value.ObjectId.Contains("Cloth") &&
                    item.Value.ObjectId.Contains("Large"))
                {
                    prices.Add(item.Value.ObjectType, new Tuple<int, CurrencyType>(160, CurrencyType.Fame));
                    clothingClothList.Add(item.Value.ObjectType);
                }

                if (item.Value.Texture2 != 0 && item.Value.ObjectId.Contains("Cloth") &&
                    item.Value.ObjectId.Contains("Small"))
                {
                    prices.Add(item.Value.ObjectType, new Tuple<int, CurrencyType>(160, CurrencyType.Fame));
                    accessoryClothList.Add(item.Value.ObjectType);
                }
            }

            ClothingDyeList = clothingDyeList.ToArray();
            ClothingClothList = clothingClothList.ToArray();
            AccessoryClothList = accessoryClothList.ToArray();
            AccessoryDyeList = accessoryDyeList.ToArray();
            log.Info("Merchat lists added.");
        }

        private static readonly string[] noShopCloths =
        {
            "Large Ivory Dragon Scale Cloth", "Small Ivory Dragon Scale Cloth",
            "Large Green Dragon Scale Cloth", "Small Green Dragon Scale Cloth",
            "Large Midnight Dragon Scale Cloth", "Small Midnight Dragon Scale Cloth",
            "Large Blue Dragon Scale Cloth", "Small Blue Dragon Scale Cloth",
            "Large Red Dragon Scale Cloth", "Small Red Dragon Scale Cloth",
            "Large Jester Argyle Cloth", "Small Jester Argyle Cloth",
            "Large Alchemist Cloth", "Small Alchemist Cloth",
            "Large Mosaic Cloth", "Small Mosaic Cloth",
            "Large Spooky Cloth", "Small Spooky Cloth",
            "Large Flame Cloth", "Small Flame Cloth",
            "Large Heavy Chainmail Cloth", "Small Heavy Chainmail Cloth",
        };
    }
}