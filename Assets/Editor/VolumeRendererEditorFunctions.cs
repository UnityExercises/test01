using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;

namespace UnityVolumeRendering
{
    public class VolumeRendererEditorFunctions
    {
        [MenuItem("Volume Rendering/Load raw dataset")]
        static void ShowDatasetImporter()
        {
            string file = EditorUtility.OpenFilePanel("Select a dataset to load", "DataFiles", "");
            if (File.Exists(file))
            {
                EditorDatasetImporter.ImportDataset(file);
            }
            else
            {
                Debug.LogError("File doesn't exist: " + file);
            }
        }

        [MenuItem("Volume Rendering/Load image sequence")]
        static void ShowSequenceImporter()
        {
            string dir = EditorUtility.OpenFolderPanel("Select a folder to load", "", "");
            if (Directory.Exists(dir))
            {
                ImageSequenceImporter importer = new ImageSequenceImporter(dir);
                VolumeDataset dataset = importer.Import();
                if (dataset != null)
                    VolumeObjectFactory.CreateObject(dataset);
            }
            else
            {
                Debug.LogError("Directory doesn't exist: " + dir);
            }
        }

        [MenuItem("Volume Rendering/Cross section/Cross section plane")]
        static void OnMenuItemClick()
        {
            VolumeRenderedObject[] objects = GameObject.FindObjectsOfType<VolumeRenderedObject>();
            if (objects.Length == 1)
                VolumeObjectFactory.SpawnCrossSectionPlane(objects[0]);
            else
            {
                CrossSectionPlaneEditorWindow wnd = new CrossSectionPlaneEditorWindow();
                wnd.Show();
            }
        }

        [MenuItem("Volume Rendering/Cross section/Box cutout")]
        static void SpawnCutoutBox()
        {
            VolumeRenderedObject[] objects = GameObject.FindObjectsOfType<VolumeRenderedObject>();
            if (objects.Length == 1)
                VolumeObjectFactory.SpawnCutoutBox(objects[0]);
        }
    }
}
