using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_language : MonoBehaviour
{
    string[] English_dialogs = { "This park stage is locked. To unlock this stage, you need to get 3 stars on all the levels of school stage and craft a book organizer.",
    "This community stage is locked. To unlock this stage, you need to get 3 stars on all the levels of house stage and craft a pen holder.",
    "This school stage is locked. To unlock this stage, you need to get 3 stars on all the levels of community stage and craft a plastic bottle pot.",
    "Banana peel is an example of biodegradable waste. It takes as long as 2 years to decompose. It can also be used as fertilizers for the plants.",
    "Pizza box is an example of biodegradable waste. It takes as long as 90 days to decompose. It also can be put on a recycle bin.",
    "Can is an example of non–biodegradable trash. It takes a 100 to 500 years to dissolve.",
    "Plastic bottle is an example of non–biodegradable trash. It takes a 450 years to dissolve. Bottles can be reused or can be turned into a plant pot.",
    "Styro cup is an example of non-biodegradable trash. Styrofoam cups breaks into tiny pieces and stay in the environment for hundreds of years.",
    "Crumpled paper is an example of biodegradable waste. It takes 2 to 6 weeks to decompose. Recycling of paper reduce greenhouse gas emissions.",
    "Plastic bag is an example of non–biodegradable trash. It takes about 1,000 years to decompose. It can be reused as a plastic wraps.",
    "Bottle jar is an example of non-biodegradable trash. It is made of a glass, and it takes 1 million years for a glass bottle to decompose.",
    "Tissue paper is an example of biodegradable waste. It takes as long as 3 years to decompose if it is wet, and 1 month if it is dry.",
    "Rotten carrot is an example of biodegradable. It decomposes after a few weeks.",
    "Candy wrapper is an example of non-biodegradable trash. It takes from 10 to 20 years to dissolve.",
    "Dried leaf is an example of biodegradable trash. It takes as long as 6 to 12 months. When decomposed, dried leaves add nutrients to the soil.",
    "Juice tetra pack is an example of non-biodegradable trash. It takes 300 years to decompose.",
    "Rotten meat is an example of biodegradable waste. It takes 1 month to more than a year for the meat to fully decompose.",
    "Orange peel is an example of biodegradable waste. It takes as long as 2 years to decompose. It can also be used as pest repellent for the plants.",
    "Rotten banana is an example of biodegradable trash. It takes 3 to 4 weeks to fully decompose. It adds nutrition to soils.",
    "Worn tire is an example of non-biodegradable trash. It takes 50 to 80 years or longer, for a tire to decompose.",
    "Paper bag is an example of biodegradable waste. It takes about a month to decompose. It can also be reused as a bag for small trashes.",
    "Continue"};

    string[] Tagalog_dialogs = { "Naka-lock ang park stage na ito. Para mabuksan ito, kailangan mong makakuha ng 3 stars sa lahat ng levels sa school stage at gumawa ng book organizer.",
    "Naka-lock ang community stage na ito. Para mabuksan ito, kailangan mong makakuha ng 3 stars sa lahat ng levels sa house stage at gumawa ng pen holder.",
    "Naka-lock ang school stage na ito. Para mabuksan ito, kailangan mong makakuha ng 3 stars sa lahat ng levels sa community stage at gumawa ng plastic bottle pot.",
    "Ang balat ng saging ay halimbawa ng nabubulok na basura. Ito ay tumatagal ng 2 taon bago ito tuluyang mabulok. Ginagamit rin itong pampataba ng mga halaman.",
    "Ang kahon ng pizza ay halimbawa ng nabubulok na basura. Ito ay tumatagal ng hanggang 90 araw upang mabulok. Maaari rin itong ilagay sa isang recycle bin.",
    "Ang lata ay halimbawa ng hindi nabubulok na basura. Inaabot ito ng 100 to 500 taon bago ito matunaw.",
    "Ang plastik na bote ay halimbawa ng hindi nabubulok na basura. Ito ay tumatagal ng 450 taon upang matunaw. Ang mga bote ay maaaring gamitin muli o maaaring gawing palayok ng halaman.",
    "Ang styro cup ay halimbawa ng hindi nabubulok na basura. Ang mga baso na Styrofoam ay nahahati sa maliliit na piraso at nananatili sa kapaligiran sa loob ng daan-daang taon.",
    "Ang lukot na papel ay halimbawa ng nabubulok na basura. Inaabot ito ng 2 hanggang 6 na linggo bago ito mabulok. Ang pag-recycle ng papel ay nakakabawas ng mga greenhouse gas emissions.",
    "Ang plastik bag ay halimbawa ng hindi nabubulok na basura. Inaabot ito ng 1,000 years bago ito matunaw. Maaari itong magamit muli bilang isang plastic wrap.",
    "Ang bote ng garapon ay halimbawa ng hindi nabubulok na basura. Ito ay gawa sa isang salamin, at tumatagal ng 1 milyong taon para mabulok ang isang bote ng salamin.",
    "Ang tisyu ay halimbawa ng nabubulok na basura. Ito ay tumatagal ng hanggang 3 taon upang mabulok kung ito ay basa, at 1 buwan kung ito ay tuyo.",
    "Ang bulok na karot ay halimbawa ng nabubulok na basura. Nabubulok ito pagkatapos ng ilang linggo.",
    "Ang balat ng kendi ay halimbawa ng hindi nabubulok na basura. Inaabot ito ng 10 hanggang 20 years bago ito matunaw.",
    "Ang tuyong dahon ay halimbawa ng nabubulok na basura. Ito ay tumatagal ng hanggang 6 hanggang 12 buwan. Kapag nabubulok, ang mga tuyong dahon ay nagdaragdag ng mga sustansya sa lupa.",
    "Ang bulok na karne ay halimbawa ng nabubulok na basura. Inaabot ito ng 1 o hanggang kahalating taon bago ito tuluyang mabulok.",
    "Ang balat ng orange ay halimbawa ng nabubulok na basura. Inaabot ito ng 2 taon bago ito tuluyang mabulok. Ito ay maaaring gamitin bilang pangkontra sa mga insekto para sa mga halaman.",
    "Ang bulok na saging ay halimbawa ng nabubulok na basura. Ito ay inaabot ng 3 hanggag 4 na linggo bago ito mabulok. Ginagamit rin itong pataba sa lupa.",
    "Ang sirang gulong ay halimbawa ng hindi nabubulok na basura. Ito ay tumatagal ng 50 hanggang 80 taon o mas matagal pa, bago mabulok ang isang gulong."};
}
