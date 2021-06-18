using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* A very generic class that handles the events of the story
 */
public class StoryHandler : MonoBehaviour
{
    //Omberg in front of Player's house
    public GameObject HideOmberg;

    //Hides the First Instance of the house
    public GameObject HideMansion1;

    //The first interactable item that pops up
    public GameObject RenneLetter; //On Omberg's desk

    //Shows the Second Instance
    public GameObject ShowMansion2;

    //Hides the Second Instance (including Parker)
    public GameObject HideMansion2;

    //Shows the Third Intance of the house
    public GameObject ShowMansion3;

    //The two items that will be available for PickUp in the third instance of the Mansion
    public GameObject PoliceNotes; //On Room's drawer
    public GameObject Cardboard; //Near the fireplace

    //Poro and his notebook that will show up after a certain time
    public GameObject PoroInWorkshop; //In front of the desk
    public GameObject PoroNotebook; //On the corner table

    //The last item of the game
    public GameObject LastItem; //On the floor

    //Atkinson's Letter near Omberg's Mansion
    public GameObject AtkinsonLetter; //On the grass

    //The first two Diary Pages
    public GameObject DiaryPage1; //Near lumberjacks tent
    public GameObject DiaryPage2; //Close to the Inn

    //The last Diary Pages on Londenberg
    public GameObject DiaryPage3; //Near the field
    public GameObject DiaryPage4; //Near the weird house

    //Poro's position in front of Omberg's house
    public GameObject PoroInOmgerg;

    //Poro's position near the post office
    public GameObject PoroInPost;


    public void Start() {

        //Sets active and innactive the apropriate items for the game
        HideOmberg.SetActive(true);
        HideMansion1.SetActive(true);
        RenneLetter.SetActive(false);
        ShowMansion2.SetActive(false);
        HideMansion2.SetActive(true);
        ShowMansion3.SetActive(false);
        PoliceNotes.SetActive(false);
        Cardboard.SetActive(false);
        PoroInWorkshop.SetActive(false);
        PoroNotebook.SetActive(false);
        LastItem.SetActive(false);

        AtkinsonLetter.SetActive(false);
        DiaryPage1.SetActive(false);
        DiaryPage2.SetActive(false);
        DiaryPage3.SetActive(false);
        DiaryPage4.SetActive(false);
        PoroInOmgerg.SetActive(false);
        PoroInPost.SetActive(false);
    }


    public void Update() {

        //While the story moves forward, show and hide items

        if (Variables.StoryIndex == 2)
            HideOmberg.SetActive(false);

        if (Variables.StoryIndex == 7)
            RenneLetter.SetActive(true);

        if(Variables.StoryIndex == 10) {
            HideMansion1.SetActive(false);
            RenneLetter.SetActive(false);
            ShowMansion2.SetActive(true);
        }

        if (Variables.StoryIndex == 15)
            PoroInOmgerg.SetActive(true);

        if(Variables.StoryIndex == 16) {
            ShowMansion2.SetActive(false);
            HideMansion2.SetActive(false);
            ShowMansion3.SetActive(true);
            PoliceNotes.SetActive(true);
            Cardboard.SetActive(true);
        }

        if(Variables.StoryIndex == 25)
            PoroInWorkshop.SetActive(true);

        if (Variables.StoryIndex == 26)
            PoroNotebook.SetActive(true);

        if (Variables.StoryIndex == 33)
            AtkinsonLetter.SetActive(true);

        if(Variables.StoryIndex == 35) {
            DiaryPage1.SetActive(true);
            DiaryPage2.SetActive(true);
        }

        if (Variables.StoryIndex == 37)
            PoroInPost.SetActive(true);

        if(Variables.StoryIndex == 41) {
            DiaryPage3.SetActive(true);
            DiaryPage4.SetActive(true);
        }


        if (Variables.StoryIndex == 48)
            LastItem.SetActive(true);
    }

}
