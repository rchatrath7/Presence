using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{

    public UserInfo playersInfo;
    public string firstName;
    public string lastName;

    public string pictureURL;

    public string personalityNeeds;
    public string personalityValues;
    public string personalityDescription;

    public List<string> suggestions;

    JSONObject j;

    public InteractionObject(string jsonString)
    {

        j = new JSONObject(jsonString);
        suggestions = new List<string>();



        playersInfo = new UserInfo();

        JSONObject pd = j.GetField("user");
        playersInfo.id = pd.GetField("id").ToString();
        playersInfo.token = pd.GetField("access_token").ToString();

        Debug.Log("id : " + playersInfo.id + "   : token : " + playersInfo.token);

        firstName = pd.GetField("first_name").ToString();
        lastName = pd.GetField("last_name").ToString();

        Debug.Log("first name : " + firstName + "   last name : " + lastName);

        pictureURL = pd.GetField("profile_picture").ToString();

        Debug.Log("profile pic : " + pictureURL);

        JSONObject p = j.GetField("personality");

        personalityNeeds = p.GetField("needs").ToString();
        personalityValues = p.GetField("values").ToString();
        personalityDescription = p.GetField("personality").ToString();

        Debug.Log("personality needs, values and description:  " + personalityNeeds + "  " + personalityValues + "   " + personalityDescription);

        JSONObject s = j.GetField("suggestions");

        Debug.Log("SUGGESTIONS:  --  ");
        foreach(JSONObject i in s.list)
        {
            if (!i.str.Contains("/") && !i.str.Contains("\\"))
            {
                suggestions.Add(i.str);
                Debug.Log(i.str);
            }
        }
    }


}

/*
 * 
{
	"suggestions":[
		"Cat Jazz Bar",
		"Major League Hacking",
		"DJ Tulio Araujo",
		"Insubstantial Pageant Faded",
		"International Space Station",
		"Lucky Jukebox Brigade",
		"Grand Budapest Hotel",
		"Awkward Date Game",
		"Princess Chelsea",
		"Alcohol Abuse Center",
		"Fabeni Caff\\u00e8",
		"Sibylle Baier",
		"Ta\\u00eds Alvarenga",
		"Tr\\u00e2nsito Seguro",
		"Lucas Rizzotto",
		"Tecnologias para",
		"vague pictures",
		"Avital Zeisler",
		"Soteria Method",
		"Carol Rizzotto",
		"Gogol Bordello",
		"New Apollos",
		"Nobel Prize",
		"John Oliver",
		"Isaac Delusion",
		"Da Brasilians",
		"Neri Oxman",
		"Smoke City",
		"Mulholland Drive"
	],
	"user":{
		"id":2,
		"first_name":"Lucas",
		"last_name":"Lucas",
		"access_token":"EAAYWcKAdGMABAOmyNgA1RHj65fgN2EOe0ta73i0VFM43xtBgtqObUOpH77sckgmr8QlrDXTOf3bTdBZCVOynj4IGubO3MuzDQnCbMSm5iyf5CyO6ZBDqUZBXRfCCZAvnWEbAdU7smOutRmIpkVxSDiQIOLRkkCYZD",
		"profile_picture":"https://scontent.xx.fbcdn.net/v/t1.0-1/p720x720/15032230_10154079833174849_4635914195367996562_n.jpg?oh=57649a9989ddec054586b12eb3ae5307&oe=5901B25D",
		"about":"Don’t let your design resist your readers. Don’t let it stand in the way of what they want to do: read."
	},
	"personality":{
		"needs":"Liberty",
		"values":"Hedonism",
		"personality":"Emotional range (Melancholy)"
	}
}

*/
