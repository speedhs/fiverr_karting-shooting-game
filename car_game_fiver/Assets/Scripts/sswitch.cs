using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sswitch : MonoBehaviour
{
  public void play()
  {SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);}
  public void quit()
  {   Debug.Log("quit");
      Application.Quit();}
  public void exit()
  {SceneManager.LoadScene(0);}
  public void retry()
  {SceneManager.LoadScene(2);}
}


