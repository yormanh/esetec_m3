/*
	Description: TextManager.cs 
	Autoría: Una ejemplo parecido lo encontré hace años en internet y desde entonces lo he ido modelando y adaptando a mi gusto y mis necesidades. 
	Busca un string en el fichero correspondiente.
*/

using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

public class TextManager : MonoBehaviour
{

	#region Fields and Propiertes

	private static TextManager mInstance;
	private static Hashtable mHashTable;
	private static char mcSeparator = '@';

	private TextManager() { }

	private static TextManager Singleton
	{
		get
		{
			if (mInstance == null)
			{
				// Because the TextManager is a component, we have to create a GameObject to attach it to.
				GameObject lNotificationObject = new GameObject("Default TextManager");

				// Add the DynamicObjectManager component, and set it as the defaultCenter
				mInstance = (TextManager)lNotificationObject.AddComponent(typeof(TextManager));
			}
			return mInstance;
		}
	}

	public static TextManager GetInstance()
	{
		return mInstance;
	}

	#endregion

	public static bool LoadLanguage(string lsFileName)
	{
		GetInstance();

		string lsFullPath = "Languages/" + lsFileName ;

		TextAsset lTextAsset = (TextAsset)UnityEngine.Resources.Load(lsFullPath, typeof(TextAsset));


		if (lTextAsset == null)
		{
			print(lsFullPath + " file not found (archivo no encontrado).");
			return false;
		}

		// create the text hash table if one doesn't exist
		if (mHashTable == null)
		{
			mHashTable = new Hashtable();
		}

		// clear the hashtable
		mHashTable.Clear();

		StringReader lReader = new StringReader(lTextAsset.text);
		string lsLine;
		while ((lsLine = lReader.ReadLine()) != null)
		{
			string[] lsParams = lsLine.Split(mcSeparator);

			if (!string.IsNullOrEmpty(lsParams[0]) && !string.IsNullOrEmpty(lsParams[1]))
			{
				// TODO: add error handling here in case of duplicate keys
				mHashTable.Add(lsParams[0], lsParams[1]);
			}
		}


		lReader.Close();

		return true;
	}

	public static string GetText(string lsKey)
	{
		if (lsKey != null && mHashTable != null)
		{
			if (mHashTable.ContainsKey(lsKey))
			{
				string lsResult = (string)mHashTable[lsKey];
				if (lsResult.Length > 0)
				{
					lsKey = lsResult.Trim();
				}
			}
		}

		return lsKey;
	}

}
