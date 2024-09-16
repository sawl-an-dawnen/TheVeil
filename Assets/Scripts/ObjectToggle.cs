using UnityEngine;

public class ObjectToggle : MonoBehaviour, IInteractable
{
	public GameObject[] set;

	public AudioClip audioClip;

	private AudioSource audioSource;

	public bool status;

	public string Prompt
	{
		get
		{
			if (status)
			{
				return "[turn off]";
			}
			return "[turn on]";
		}
	}

	private void Awake()
	{
		audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
	}

	public void Interact()
	{
		if (audioClip != null)
		{
			audioSource.PlayOneShot(audioClip);
		}
		status = !status;
		GameObject[] array = set;
		foreach (GameObject obj in array)
		{
			obj.SetActive(!obj.activeSelf);
		}
	}
}
