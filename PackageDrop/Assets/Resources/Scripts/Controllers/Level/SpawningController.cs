using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawning controller, attached to each spawn point in order for it to spawn packages according to its variables.
/// </summary>
public class SpawningController : MonoBehaviour {

	/// <summary>
	/// Should this spawn point infinitely create packages
	/// </summary>
	public bool infiniteCreate = false;
	/// <summary>
	/// The time between spawns of the packages
	/// </summary>
	public float spawnTime = 3.0f;
	/// <summary>
	/// All the packages to spawn
	/// </summary>
	public List<GameObject> allPackages;
	/// <summary>
	/// The types of packages available to spawn
	/// </summary>
	public List<GameObject> packageTypes;
	private int packageCount;
	private float timeCount = 0;

	void Start(){
		LevelController.instance.NumPackagesLeft += allPackages.Count;
		packageCount = allPackages.Count;
	}

	// Update is called once per frame
	void Update () {
		timeCount += Time.deltaTime;
		if (timeCount > spawnTime && packageCount > 0) {
			//instantiate the new packace from allPackages list and set its position to the object this script is attached to
			GameObject package = Instantiate (allPackages[packageCount - 1]);
			package.transform.SetParent (LevelController.instance.theLevelObjects.transform, false);
			package.transform.localPosition = gameObject.transform.localPosition;
			packageCount--;

			timeCount = 0;
			//if infinite create is on, loop through all packages again and again
			if ((LevelController.instance.NumPackagesLeft == 0 || packageCount == 0) && infiniteCreate) {
				LevelController.instance.NumPackagesLeft += allPackages.Count;
				packageCount += allPackages.Count;
			}
		}
	}

	/// <summary>
	/// Auto generates the amount of packages specified by allPackages
	/// </summary>
	public void AutoGenerate(){
		for (int z = 0; z < allPackages.Count; z++) {
			//pick a random package from all the possible packages on the level
			int random = UnityEngine.Random.Range (0, packageTypes.Count);
			allPackages [z] = packageTypes [random];
		}
	}
}
