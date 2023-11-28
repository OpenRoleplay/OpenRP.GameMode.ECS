using SampSharp.Core.Natives.NativeObjects;
using SampSharp.GameMode;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;

namespace OpenRP.ColAndreas
{
    public class ColAndreasHelper
    {
        #region Variables
        static public readonly int VERSION = (10400); //a.b.c 10000*a+100*b+c

        static public readonly int MAX_OBJECTS = (50000); // This is the internal limit.

        static public readonly int WATER_MODEL = (20000);

        enum ObjectType
        {
            Normal, // This used to be called "Object"
            Dynamic
        }

        class ObjectStruct
        {
            public GlobalObject Object = null;
            public int CollisionId = -1;
            public ObjectType Type;
        }

        static List<ObjectStruct> ObjectData = new List<ObjectStruct>();

        #endregion // Variables

        #region Functions

        /// <summary>
        /// Attempts to load data and initialize the plugin.
        /// </summary>
        /// <returns>true if successful</returns>
        /// <returns>false if unsuccessful</returns>
        static public bool Init()
        {
            return ColAndreasInternal.Instance.Init();
        }

        /// <summary>
        /// Attempts to remove all the buildings from the world within the given radius.
        /// </summary>
        /// <param name="modelId">The object's model.</param>
        /// <param name="x,y,z">The center point of the radius circle.</param>
        /// <param name="radius">The radius to remove buildings.</param>
        /// <returns>true if successful</returns>
        /// <returns>false if unsuccessful</returns>
        static public bool RemoveBuilding(int modelId, float x, float y, float z, float radius)
        {
            return ColAndreasInternal.Instance.RemoveBuilding(modelId, x, y, z, radius);
        }
        static public bool RemoveBuilding(int modelId, Vector3 center, float radius)
        {
            return ColAndreasInternal.Instance.RemoveBuilding(modelId, center.X, center.Y, center.Z, radius);
        }

        /// <summary>
        /// Attempts to detect collision.
        /// </summary>
        /// <param name="startX,startY,startZ">The starting point.</param>
        /// <param name="endX,endY,endZ">The ending point.</param>
        /// <param name="x,y,z">The resulting hit position.</param>
        /// <returns>0 if nothing is detected.</returns>
        /// <returns>WATER_MODEL if it hit water.</returns>
        /// <returns>modelId if it made collision.</returns>
        static public int RayCastLine(float startX, float startY, float startZ, float endX, float endY, float endZ, out float x, out float y, out float z)
        {
            return ColAndreasInternal.Instance.RayCastLine(startX, startY, startZ, endX, endY, endZ, out x, out y, out z);
        }
        static public int RayCastLine(Vector3 start, Vector3 end, out Vector3 hit)
        {
            int modelId = ColAndreasInternal.Instance.RayCastLine(start.X, start.Y, start.Z, end.X, end.Y, end.Z, out float x, out float y, out float z);

            hit = (modelId == 0) ? Vector3.Zero : new Vector3(x, y, z);
            return modelId;
        }

        /// <summary>
        /// Attempts to detect collision with dynamic object (ColAndreas.CreateObject).
        /// </summary>
        /// <param name="startX,startY,startZ">The starting point.</param>
        /// <param name="endX,endY,endZ">The ending point.</param>
        /// <param name="x,y,z">The resulting hit position.</param>
        /// <returns>-1 if collided with static object or water.</returns>
        /// <returns>0 if didn't collide with anything.</returns>
        /// <returns>collisionId if it made collision.</returns>
        static public int RayCastLineId(float startX, float startY, float startZ, float endX, float endY, float endZ, out float x, out float y, out float z)
        {
            return ColAndreasInternal.Instance.RayCastLineId(startX, startY, startZ, endX, endY, endZ, out x, out y, out z);
        }
        static public int RayCastLineId(Vector3 start, Vector3 end, out Vector3 hit)
        {
            int modelId = ColAndreasInternal.Instance.RayCastLineId(start.X, start.Y, start.Z, end.X, end.Y, end.Z, out float x, out float y, out float z);

            hit = (modelId == 0) ? Vector3.Zero : new Vector3(x, y, z);
            return modelId;
        }

        /// <summary>
        /// Attempts to detect collision with object that has ExtraId (ColAndreas.CreateObject).
        /// </summary>
        /// <param name="startX,startY,startZ">The starting point.</param>
        /// <param name="endX,endY,endZ">The ending point.</param>
        /// <param name="x,y,z">The resulting hit position.</param>
        /// <returns>-1 if collided with static object or water.</returns>
        /// <returns>-1 if collided with object that has no extra id.</returns>
        /// <returns>0 if didn't collide with anything.</returns>
        /// <returns>collisionId if it made collision.</returns>
        static public int RayCastLineExtraId(float startX, float startY, float startZ, float endX, float endY, float endZ, out float x, out float y, out float z)
        {
            return ColAndreasInternal.Instance.RayCastLineExtraId(startX, startY, startZ, endX, endY, endZ, out x, out y, out z);
        }
        static public int RayCastLineExtraId(Vector3 start, Vector3 end, out Vector3 hit)
        {
            int modelId = ColAndreasInternal.Instance.RayCastLineExtraId(start.X, start.Y, start.Z, end.X, end.Y, end.Z, out float x, out float y, out float z);

            hit = (modelId == 0) ? Vector3.Zero : new Vector3(x, y, z);
            return modelId;
        }

        /// <summary>
        /// Attempts to detect collision with objects.
        /// </summary>
        /// <param name="startX,startY,startZ">The starting point.</param>
        /// <param name="endX,endY,endZ">The ending point.</param>
        /// <param name="x[],y[],z[]">The resulting hit positions.</param>
        /// <param name="distance[]">The resulting distance of each hit.</param>
        /// <param name="modelId[]">The resulting modelIds of each hit.</param>
        /// <param name="size">The maximum array size.</param>
        /// <returns>-1 it hit more objects than allowed by size.</returns>
        /// <returns>0 if didn't collide with anything.</returns>
        /// <returns>1+ the number of objects it hit.</returns>
        static public int RayCastMultiLine(float startX, float startY, float startZ, float endX, float endY, float endZ, out float[] x, out float[] y, out float[] z, out float[] distance, out int[] modelId, int size)
        {
            return ColAndreasInternal.Instance.RayCastMultiLine(startX, startY, startZ, endX, endY, endZ, out x, out y, out z, out distance, out modelId, size);
        }
        static public int RayCastMultiLine(Vector3 start, Vector3 end, out Vector3[] positions, out float[] distances, out int[] modelIds, int arraySize)
        {
            positions = new Vector3[arraySize];

            int count = ColAndreasInternal.Instance.RayCastMultiLine(
                start.X, start.Y, start.Z, end.X, end.Y, end.Z,
                out float[] x, out float[] y, out float[] z, out distances, out modelIds, arraySize
            );

            for (int i = 0; i < count; i++)
            {
                positions[i] = new Vector3(x[i], y[i], z[i]);
            }
            return count;
        }

        /// <summary>
        /// Attempts to detect collision with object, gives the rotation.
        /// </summary>
        /// <param name="startX,startY,startZ">The starting point.</param>
        /// <param name="endX,endY,endZ">The ending point.</param>
        /// <param name="x,y,z">The resulting hit position.</param>
        /// <param name="rx,ry,rz">The resulting hit rotation.</param>
        /// <returns>0 if didn't collide with anything.</returns>
        /// <returns>WATER_MODEL if it hit water.</returns>
        /// <returns>modelId if it made collision.</returns>
        static public int RayCastLineAngle(float startX, float startY, float startZ, float endX, float endY, float endZ, out float x, out float y, out float z, out float rx, out float ry, out float rz)
        {
            return ColAndreasInternal.Instance.RayCastLineAngle(startX, startY, startZ, endX, endY, endZ, out x, out y, out z, out rx, out ry, out rz);
        }
        static public int RayCastLineAngle(Vector3 start, Vector3 end, out Vector3 hit, out Vector3 hitRotation)
        {
            int modelId = ColAndreasInternal.Instance.RayCastLineAngle(
                start.X, start.Y, start.Z, end.X, end.Y, end.Z,
                out float x, out float y, out float z, out float rx, out float ry, out float rz
            );

            hit = (modelId == 0) ? Vector3.Zero : new Vector3(x, y, z);
            hitRotation = (modelId == 0) ? Vector3.Zero : new Vector3(rx, ry, rz);
            return modelId;
        }

        /// <summary>
        /// Attempts to detect collision with object, gives quaternion and position of object.
        /// </summary>
        /// <param name="startX,startY,startZ">The starting point.</param>
        /// <param name="endX,endY,endZ">The ending point.</param>
        /// <param name="x,y,z">The point that the ray collided.</param>
        /// <param name="rx,ry,rz,rw">The quaternion rotation of the object that the ray collided.</param>
        /// <param name="cx,cy,cz">The position of the object that the ray collided.</param>
        /// <returns>0 if didn't collide with anything.</returns>
        /// <returns>WATER_MODEL if it hit water.</returns>
        /// <returns>modelId if it made collision.</returns>
        static public int RayCastLineEx(float startX, float startY, float startZ, float endX, float endY, float endZ, out float x, out float y, out float z, out float rx, out float ry, out float rz, out float rw, out float cx, out float cy, out float cz)
        {
            return ColAndreasInternal.Instance.RayCastLineEx(startX, startY, startZ, endX, endY, endZ, out x, out y, out z, out rx, out ry, out rz, out rw, out cx, out cy, out cz);
        }
        static public int RayCastLineEx(Vector3 start, Vector3 end, out Vector3 hit, out Vector4 quaternion, out Vector3 position)
        {
            int modelId = ColAndreasInternal.Instance.RayCastLineEx(
                start.X, start.Y, start.Z, end.X, end.Y, end.Z,
                out float x, out float y, out float z,
                out float rx, out float ry, out float rz, out float rw,
                out float cx, out float cy, out float cz
            );

            hit = (modelId == 0) ? Vector3.Zero : new Vector3(x, y, z);
            quaternion = (modelId == 0) ? Vector4.Zero : new Vector4(rx, ry, rz, rw);
            position = (modelId == 0) ? Vector3.Zero : new Vector3(cx, cy, cz);
            return modelId;
        }

        /// <summary>
        /// Attempts to detect collision with object, gives position and rotation of object.
        /// </summary>
        /// <param name="startX,startY,startZ">The starting point.</param>
        /// <param name="endX,endY,endZ">The ending point.</param>
        /// <param name="x,y,z">The point that the ray collided.</param>
        /// <param name="rx,ry,rz">The rotation of the face that the ray collided.</param>
        /// <param name="ocx,ocy,ocz">The position of the object that the ray collided.</param>
        /// <param name="orx,ory,orz">The rotation of the object that the ray collided.</param>
        /// <returns>0 if didn't collide with anything.</returns>
        /// <returns>WATER_MODEL if it hit water.</returns>
        /// <returns>modelId if it made collision.</returns>
        static public int RayCastLineAngleEx(float startX, float startY, float startZ, float endX, float endY, float endZ, out float x, out float y, out float z, out float rx, out float ry, out float rz, out float ocx, out float ocy, out float ocz, out float orx, out float ory, out float orz)
        {
            return ColAndreasInternal.Instance.RayCastLineAngleEx(startX, startY, startZ, endX, endY, endZ, out x, out y, out z, out rx, out ry, out rz, out ocx, out ocy, out ocz, out orx, out ory, out orz);
        }
        static public int RayCastLineAngleEx(Vector3 start, Vector3 end, out Vector3 hit, out Vector3 surfaceRotation, out Vector3 position, out Vector3 rotation)
        {
            int modelId = ColAndreasInternal.Instance.RayCastLineAngleEx(
                start.X, start.Y, start.Z, end.X, end.Y, end.Z,
                out float x, out float y, out float z,
                out float rx, out float ry, out float rz,
                out float ocx, out float ocy, out float ocz,
                out float orx, out float ory, out float orz
            );

            hit = (modelId == 0) ? Vector3.Zero : new Vector3(x, y, z);
            surfaceRotation = (modelId == 0) ? Vector3.Zero : new Vector3(rx, ry, rz);
            position = (modelId == 0) ? Vector3.Zero : new Vector3(ocx, ocy, ocz);
            rotation = (modelId == 0) ? Vector3.Zero : new Vector3(orx, ory, orz);
            return modelId;
        }

        /// <summary>
        /// Get the reflection vector of the detected collision object.
        /// </summary>
        /// <param name="startX,startY,startZ">The starting point.</param>
        /// <param name="endX,endY,endZ">The ending point.</param>
        /// <param name="x,y,z">The point the ray collided at.</param>
        /// <param name="nx,ny,nz">The reflection vector of the face the ray collided.</param>
        /// <returns>0 if didn't collide with anything.</returns>
        /// <returns>WATER_MODEL if it hit water.</returns>
        /// <returns>modelId if it made collision.</returns>
        static public int RayCastReflectionVector(float startX, float startY, float startZ, float endX, float endY, float endZ, out float x, out float y, out float z, out float nx, out float ny, out float nz)
        {
            return ColAndreasInternal.Instance.RayCastReflectionVector(startX, startY, startZ, endX, endY, endZ, out x, out y, out z, out nx, out ny, out nz);
        }
        static public int RayCastReflectionVector(Vector3 start, Vector3 end, out Vector3 hit, out Vector3 reflectionVector)
        {
            int modelId = ColAndreasInternal.Instance.RayCastReflectionVector(
                start.X, start.Y, start.Z, end.X, end.Y, end.Z,
                out float x, out float y, out float z, out float nx, out float ny, out float nz
            );

            hit = (modelId == 0) ? Vector3.Zero : new Vector3(x, y, z);
            reflectionVector = (modelId == 0) ? Vector3.Zero : new Vector3(nx, ny, nz);
            return modelId;
        }

        /// <summary>
        /// Get the surface normal of the detected collision object.
        /// </summary>
        /// <param name="startX,startY,startZ">The starting point.</param>
        /// <param name="endX,endY,endZ">The ending point.</param>
        /// <param name="x,y,z">The point the ray collided at.</param>
        /// <param name="nx,ny,nz">The surface normal of the face the ray collided.</param>
        /// <returns>0 if didn't collide with anything.</returns>
        /// <returns>WATER_MODEL if it hit water.</returns>
        /// <returns>modelId if it made collision.</returns>
        static public int RayCastLineNormal(float startX, float startY, float startZ, float endX, float endY, float endZ, out float x, out float y, out float z, out float nx, out float ny, out float nz)
        {
            return ColAndreasInternal.Instance.RayCastLineNormal(startX, startY, startZ, endX, endY, endZ, out x, out y, out z, out nx, out ny, out nz);
        }
        static public int RayCastLineNormal(Vector3 start, Vector3 end, out Vector3 hit, out Vector3 surfaceNormal)
        {
            int modelId = ColAndreasInternal.Instance.RayCastLineNormal(
                start.X, start.Y, start.Z, end.X, end.Y, end.Z,
                out float x, out float y, out float z, out float nx, out float ny, out float nz
            );

            hit = (modelId == 0) ? Vector3.Zero : new Vector3(x, y, z);
            surfaceNormal = (modelId == 0) ? Vector3.Zero : new Vector3(nx, ny, nz);
            return modelId;
        }

        /// <summary>
        /// Tests whether the object collides with the world.
        /// </summary>
        /// <param name="modelId">The model of the object to test.</param>
        /// <param name="x,y,z">The position of the object to test.</param>
        /// <param name="rx,ry,rz">The rotation of the object to test.</param>
        /// <returns>0 doesn't collide with the world.</returns>
        /// <returns>1 collides with the world.</returns>
        static public int ContactTest(int modelId, float x, float y, float z, float rx, float ry, float rz)
        {
            return ColAndreasInternal.Instance.ContactTest(modelId, x, y, z, rx, ry, rz);
        }
        static public int ContactTest(int modelId, Vector3 position, Vector3 rotation)
        {
            return ColAndreasInternal.Instance.ContactTest(modelId, position.X, position.Y, position.Z, rotation.X, rotation.Y, rotation.Z);
        }

        /// <summary>
        /// Converts GTA euler rotations to quaternion angles.
        /// </summary>
        /// <param name="rx,ry,rz">GTA euler rotation to be converted</param>
        /// <param name="x,y,z,w">The quaternion angles returned</param>
        /// <returns>Always 1</returns>
        static public int EulerToQuat(float rx, float ry, float rz, out float x, out float y, out float z, out float w)
        {
            return ColAndreasInternal.Instance.EulerToQuat(rx, ry, rz, out x, out y, out z, out w);
        }
        static public int EulerToQuat(Vector3 rotation, out Vector4 quaternion)
        {
            int result = ColAndreasInternal.Instance.EulerToQuat(
                rotation.X, rotation.Y, rotation.Z,
                out float x, out float y, out float z, out float w
            );

            quaternion = new Vector4(x, y, z, w);
            return result;
        }

        /// <summary>
        /// Converts quaternion angles to GTA euler rotation.
        /// </summary>
        /// <param name="x,y,z,w">The quaternion angles to be converted</param>
        /// <param name="rx,ry,rz">GTA euler rotation returned</param>
        /// <returns>Always 1</returns>
        static public int QuatToEuler(Vector4 quaternion, out Vector3 rotation)
        {
            int result = ColAndreasInternal.Instance.QuatToEuler(
                quaternion.X, quaternion.Y, quaternion.Z, quaternion.W,
                out float x, out float y, out float z
            );

            rotation = new Vector3(x, y, z);
            return result;
        }

        /// <summary>
        /// Gets the bounding sphere of the modelId.
        /// </summary>
        /// <param name="modelId">The modelId of the object</param>
        /// <param name="offsetX,offsetY,offsetZ">The retrieved offset from it's position.</param>
        /// <param name="radius">The radius of the sphere.</param>
        /// <returns>0 if modelId is invalid</returns>
        /// <returns>1 if successful</returns>
        static public int GetModelBoundingSphere(int modelId, out float offsetX, out float offsetY, out float offsetZ, out float radius)
        {
            return ColAndreasInternal.Instance.GetModelBoundingSphere(modelId, out offsetX, out offsetY, out offsetZ, out radius);
        }
        static public int GetModelBoundingSphere(int modelId, out Vector3 offset, out float radius)
        {
            int result = ColAndreasInternal.Instance.GetModelBoundingSphere(
                modelId,
                out float offsetX, out float offsetY, out float offsetZ, out radius
            );

            offset = new Vector3(offsetX, offsetY, offsetZ);
            return result;
        }

        /// <summary>
        /// Gets the bounding box of the modelId.
        /// </summary>
        /// <param name="modelId">The modelId of the object</param>
        /// <param name="minX,minY,minZ">The retrieved point of the one side of the box</param>
        /// <param name="maxX,maxY,maxZ">The retrieved point of the other side of the box</param>
        /// <returns>0 if modelId is invalid</returns>
        /// <returns>1 if successful</returns>
        static public int GetModelBoundingBox(int modelId, out float minX, out float minY, out float minZ, out float maxX, out float maxY, out float maxZ)
        {
            return ColAndreasInternal.Instance.GetModelBoundingBox(modelId, out minX, out minY, out minZ, out maxX, out maxY, out maxZ);
        }
        static public int GetModelBoundingBox(int modelId, out Vector3 min, out Vector3 max)
        {
            int result = ColAndreasInternal.Instance.GetModelBoundingBox(
                modelId,
                out float minX, out float minY, out float minZ,
                out float maxX, out float maxY, out float maxZ
            );

            min = new Vector3(minX, minY, minZ);
            max = new Vector3(maxX, maxY, maxZ);
            return result;
        }

        /// <summary>
        /// Creates a collision object, this is not a physical object.
        /// </summary>
        /// <param name="modelId">The modelId of the collision object.</param>
        /// <param name="x,y,z">The position of the collision object.</param>
        /// <param name="rx,ry,rz">The rotation of the collision object.</param>
        /// <param name="index">Whether or not to index this for further modifications.</param>
        /// <returns>-1 if too many collision objects.</returns>
        /// <returns>-1 if index is set to false.</returns>
        /// <returns>collisionId if successful.</returns>
        static public int CreateObject(int modelId, float x, float y, float z, float rx, float ry, float rz, bool index = false)
        {
            return ColAndreasInternal.Instance.CreateObject(modelId, x, y, z, rx, ry, rz, index);
        }
        static public int CreateObject(int modelId, Vector3 position, Vector3 rotation, bool index = false)
        {
            return ColAndreasInternal.Instance.CreateObject(modelId, position.X, position.Y, position.Z, rotation.X, rotation.Y, rotation.Z, index);
        }

        /// <summary>
        /// Removes a collision object.
        /// </summary>
        /// <param name="collisionId">The collisionId of the object.</param>
        /// <returns>-1 if the specified model has no collision.</returns>
        /// <returns>-1 if it's not managed.</returns>
        /// <returns>The collisionId of the collision object.</returns>
        static public int DestroyObject(int collisionId)
        {
            return ColAndreasInternal.Instance.DestroyObject(collisionId);
        }

        /// <summary>
        /// Sets the collision object's position.
        /// </summary>
        /// <param name="collisionId">The collisionId of the object.</param>
        /// <param name="x,y,z">The position to set.</param>
        /// <returns>0 Invalid object.</returns>
        /// <returns>1 Successful.</returns>
        static public int SetObjectPos(int collisionId, float x, float y, float z)
        {
            return ColAndreasInternal.Instance.SetObjectPos(collisionId, x, y, z);
        }
        static public int SetObjectPos(int collisionId, Vector3 position)
        {
            return ColAndreasInternal.Instance.SetObjectPos(collisionId, position.X, position.Y, position.Z);
        }

        /// <summary>
        /// Sets the collision object's rotation.
        /// </summary>
        /// <param name="collisionId">The collisionId of the object.</param>
        /// <param name="rx,ry,rz">The rotation to set.</param>
        /// <returns>0 Invalid object.</returns>
        /// <returns>1 Successful.</returns>
        static public int SetObjectRot(int collisionId, float rx, float ry, float rz)
        {
            return ColAndreasInternal.Instance.SetObjectRot(collisionId, rx, ry, rz);
        }
        static public int SetObjectRot(int collisionId, Vector3 rotation)
        {
            return ColAndreasInternal.Instance.SetObjectPos(collisionId, rotation.X, rotation.Y, rotation.Z);
        }

        /// <summary>
        /// Sets custom data for the collision object.
        /// </summary>
        /// <param name="collisionId">The collisionId of the object.</param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>Always 1</returns>
        static public int SetObjectExtraID(int collisionId, int key, int value)
        {
            return ColAndreasInternal.Instance.SetObjectExtraID(collisionId, key, value);
        }

        /// <summary>
        /// Gets custom data for the collision object.
        /// </summary>
        /// <param name="collisionId">The collisionId of the object.</param>
        /// <param name="key"></param>
        /// <returns>The value of the collision object data.</returns>
        static public int GetObjectExtraID(int collisionId, int key)
        {
            return ColAndreasInternal.Instance.GetObjectExtraID(collisionId, key);
        }

        static ObjectStruct GetData(GlobalObject obj)
        {
            foreach (ObjectStruct objectData in ObjectData)
            {
                if (objectData.Object == obj)
                {
                    return objectData;
                }
            }
            return null;
        }

        /// <summary>
        /// Creates a physical object with the collision object.
        /// </summary>
        /// <param name="modelId">The model of the object.</param>
        /// <param name="x,y,z">The position of the object.</param>
        /// <param name="rx,ry,rz">The rotation of the object.</param>
        /// <param name="streamDistance">The distance it appears for the player</param>
        /// <returns>null if unsuccessful</returns>
        /// <returns>GlobalObject if successful</returns>
        static public GlobalObject CreateObject(int modelId, float x, float y, float z, float rx, float ry, float rz, float streamDistance = 300.0f)
        {
            GlobalObject obj = new GlobalObject(modelId, new Vector3(x, y, z), new Vector3(rx, ry, rz), streamDistance);

            if (obj == null)
            {
                return null;
            }

            int collisionId = CreateObject(modelId, x, y, z, rx, ry, rz, true);

            if (collisionId == -1)
            {
                obj.Dispose();
                return null;
            }

            ObjectStruct objectData = new ObjectStruct
            {
                Object = obj,
                CollisionId = collisionId,
                Type = ObjectType.Normal
            };
            ObjectData.Add(objectData);
            return obj;
        }
        static public GlobalObject CreateObject(int modelId, Vector3 position, Vector3 rotation, float streamDistance = 300.0f)
        {
            return CreateObject(modelId, position.X, position.Y, position.Z, rotation.X, rotation.Y, rotation.Z, streamDistance);
        }

        /// <summary>
        /// Destroys the physical and collision object.
        /// </summary>
        /// <param name="GlobalObject">The instance of the GlobalObject</param>
        /// <returns>false if unsuccessful</returns>
        /// <returns>true if successful</returns>
        static public bool DestroyObject(GlobalObject obj)
        {
            ObjectStruct objectData = GetData(obj);

            if (objectData == null)
            {
                return false;
            }

            DestroyObject(objectData.CollisionId);
            obj.Dispose();
            ObjectData.Remove(objectData);
            return true;
        }

        /// <summary>
        /// Sets the position of the physical and collision object.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        static public bool SetObjectPos(GlobalObject obj, Vector3 position)
        {
            ObjectStruct objectData = GetData(obj);

            if (objectData == null)
            {
                return false;
            }

            SetObjectPos(objectData.CollisionId, position.X, position.Y, position.Z);
            obj.Position = position;
            return true;
        }

        /// <summary>
        /// Sets the rotation of the physical and collision object.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        static public bool SetObjectRot(GlobalObject obj, Vector3 rotation)
        {
            ObjectStruct objectData = GetData(obj);

            if (objectData == null)
            {
                return false;
            }

            SetObjectRot(objectData.CollisionId, rotation.X, rotation.Y, rotation.Z);
            obj.Rotation = rotation;
            return true;
        }

        /// <summary>
        /// Destroys all the physical and collision objects.
        /// </summary>
        /// <returns></returns>
        static public bool DestroyObjects()
        {
            foreach (ObjectStruct objectData in ObjectData)
            {
                DestroyObject(objectData.Object);
            }
            return true;
        }

        /// <summary>
        /// ColAndreas wrapper for the MapAndreas function.
        /// </summary>
        /// <param name="x,y,z"></param>
        /// <returns></returns>
        static public bool FindZ_For2DCoord(float x, float y, out float z)
        {
            if (RayCastLine(x, y, 700.0f, x, y, -1000.0f, out x, out y, out z) <= 0)
            {
                return false;
            }
            return true;
        }
        static public bool FindZ_For2DCoord(Vector2 xy, out float z)
        {
            if (RayCastLine(xy.X, xy.Y, 700.0f, xy.X, xy.Y, -1000.0f, out float x, out float y, out z) <= 0)
            {
                return false;
            }
            return true;
        }
        static public Vector3 FindZ_For2DCoord(Vector3 position)
        {
            if (RayCastLine(position.X, position.Y, 700.0f, position.X, position.Y, -1000.0f, out float x, out float y, out float z) <= 0)
            {
                return Vector3.Zero;
            }
            return new Vector3(x, y, z);
        }

        /// <summary>
        /// Creates a sphere of detections with the x,y,z in the center.
        /// </summary>
        /// <param name="x,y,z">Center of the sphere.</param>
        /// <param name="radius">The radius of the sphere.</param>
        /// <param name="collisions">The detected collisions of the sphere.</param>
        /// <param name="intensity">The intensity of the detections.</param>
        /// <returns></returns>
        static public int RayCastExplode(float x, float y, float z, float radius, out Vector3[] collisions, float intensity = 20.0f)
        {
            collisions = new Vector3[0];

            if (intensity < 1.0 || intensity > 360.0 || (((360.0 / intensity) - Math.Round((360.0 / intensity))) * intensity) != 0.0)
            {
                return 0;
            }

            List<Vector3> positions = new List<Vector3>();

            for (float lat = -180.0f; lat < 180.0f; lat += (intensity * 0.75f))
            {
                for (float lon = -90.0f; lon < 90.0f; lon += intensity)
                {
                    float LAT = (float)(lat * Math.PI / 180.0f);
                    float LON = (float)(lon * Math.PI / 180.0f);
                    float cX = (float)(-radius * Math.Cos(LAT) * Math.Cos(LON));
                    float cY = (float)(radius * Math.Cos(LAT) * Math.Sin(LON));
                    float cZ = (float)(radius * Math.Sin(LAT));

                    if (RayCastLine(x, y, z, x + cX, y + cY, z + cZ, out cX, out cY, out cZ) <= 0) continue;

                    positions.Add(new Vector3(cX, cY, cZ));
                }
            }

            collisions = positions.ToArray();
            return positions.Count;
        }

        /// <summary>
        /// Checks if there's a collision below the player.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="tolerance"></param>
        /// <returns>true if they're on top of something.</returns>
        /// <returns>false if they're not.</returns>
        static public bool IsPlayerOnSurface(BasePlayer player, float tolerance = 1.5f)
        {
            Vector3 position = player.Position;

            if (RayCastLine(position.X, position.Y, position.Z, position.X, position.Y, (position.Z - tolerance), out float x, out float y, out float z) <= 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Removes any barrier object from the game.
        /// </summary>
        /// <returns></returns>
        static public bool RemoveBarriers()
        {
            int[] barrierIds =
            {
                16439, 16438, 16437, 16436, 4527, 4526, 4525, 4524, 4523, 4517,
                4516, 4515, 4514, 4513, 4512, 4511, 4510, 4509, 4508, 4507,
                4506, 4505, 4504, 1662
            };

            for (int i = 0, l = barrierIds.Length; i < l; i++)
            {
                RemoveBuilding(barrierIds[i], 0.0f, 0.0f, 0.0f, 4242.6407f);
            }
            return true;
        }

        /// <summary>
        /// Removes all the breakable objects in the game.
        /// </summary>
        /// <returns></returns>
        static public bool RemoveBreakableBuildings()
        {
            int[] breakableIds =
            {
                625, 626, 627, 628, 629, 630, 631, 632, 633, 642,
                643, 644, 646, 650, 716, 717, 737, 738, 792, 858,
                881, 882, 883, 884, 885, 886, 887, 888, 889, 890,
                891, 892, 893, 894, 895, 904, 905, 941, 955, 956,
                959, 961, 990, 993, 996, 1209, 1211, 1213, 1219, 1220,
                1221, 1223, 1224, 1225, 1226, 1227, 1228, 1229, 1230, 1231,
                1232, 1235, 1238, 1244, 1251, 1255, 1257, 1262, 1264, 1265,
                1270, 1280, 1281, 1282, 1283, 1284, 1285, 1286, 1287, 1288,
                1289, 1290, 1291, 1293, 1294, 1297, 1300, 1302, 1315, 1328,
                1329, 1330, 1338, 1350, 1351, 1352, 1370, 1373, 1374, 1375,
                1407, 1408, 1409, 1410, 1411, 1412, 1413, 1414, 1415, 1417,
                1418, 1419, 1420, 1421, 1422, 1423, 1424, 1425, 1426, 1428,
                1429, 1431, 1432, 1433, 1436, 1437, 1438, 1440, 1441, 1443,
                1444, 1445, 1446, 1447, 1448, 1449, 1450, 1451, 1452, 1456,
                1457, 1458, 1459, 1460, 1461, 1462, 1463, 1464, 1465, 1466,
                1467, 1468, 1469, 1470, 1471, 1472, 1473, 1474, 1475, 1476,
                1477, 1478, 1479, 1480, 1481, 1482, 1483, 1514, 1517, 1520,
                1534, 1543, 1544, 1545, 1551, 1553, 1554, 1558, 1564, 1568,
                1582, 1583, 1584, 1588, 1589, 1590, 1591, 1592, 1645, 1646,
                1647, 1654, 1664, 1666, 1667, 1668, 1669, 1670, 1672, 1676,
                1684, 1686, 1775, 1776, 1949, 1950, 1951, 1960, 1961, 1962,
                1975, 1976, 1977, 2647, 2663, 2682, 2683, 2885, 2886, 2887,
                2900, 2918, 2920, 2925, 2932, 2933, 2942, 2943, 2945, 2947,
                2958, 2959, 2966, 2968, 2971, 2977, 2987, 2988, 2989, 2991,
                2994, 3006, 3018, 3019, 3020, 3021, 3022, 3023, 3024, 3029,
                3032, 3036, 3058, 3059, 3067, 3083, 3091, 3221, 3260, 3261,
                3262, 3263, 3264, 3265, 3267, 3275, 3276, 3278, 3280, 3281,
                3282, 3302, 3374, 3409, 3460, 3516, 3794, 3795, 3797, 3853,
                3855, 3864, 3884, 11103, 12840, 16627, 16628, 16629, 16630, 16631,
                16632, 16633, 16634, 16635, 16636, 16732, 17968
            };

            for (int i = 0, l = breakableIds.Length; i < l; i++)
            {
                RemoveBuilding(breakableIds[i], 0.0f, 0.0f, 0.0f, 4242.6407f);
            }
            return true;
        }

        /// <summary>
        /// Checks if the player is in water.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="depth"></param>
        /// <param name="playerDepth"></param>
        /// <returns></returns>
        static public bool IsPlayerInWater(BasePlayer player, out float depth, out float playerDepth)
        {
            Vector3 position = player.Position;

            depth = float.NaN;
            playerDepth = float.NaN;

            int count = RayCastMultiLine(
                position.X, position.Y, (position.Z + 1000.0f), position.X, position.Y, (position.Y - 1000.0f),
                out float[] x, out float[] y, out float[] z, out float[] distance, out int[] modelId, 10
            );

            if (count <= 0)
            {
                return false;
            }

            for (int i = 0; i < count; i++)
            {
                if (modelId[i] != WATER_MODEL) continue;

                for (int j = 0; j < count; j++)
                {
                    if (z[j] < depth)
                    {
                        depth = z[j];
                    }
                }

                depth = z[i] - depth;

                if (depth < 0.001f && depth > -0.001f)
                {
                    depth = 100.0f;
                }

                playerDepth = z[i] - position.Z;

                if (playerDepth < -2.0)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the player is near any water source.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="distance"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        static public bool IsPlayerNearWater(BasePlayer player, float distance = 3.0f, float height = 3.0f)
        {
            // Modified by Ikkentim
            for (float angle = 0; angle < (float)(Math.PI * 2); angle += (float)(Math.PI / 3))
            {
                Matrix rotation = Matrix.CreateRotationZ(angle);
                Vector3 offset = Vector3.Transform(Vector3.Forward * distance, rotation);
                Vector3 start = player.Position + offset + Vector3.Up * height;
                Vector3 end = player.Position + offset - Vector3.Up * height;

                if (RayCastLine(start, end, out Vector3 hit) == WATER_MODEL)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the water is in front of the player.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="maxDistance"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        static public bool IsPlayerFacingWater(BasePlayer player, float maxDistance = 10.0f, float height = 5.0f)
        {
            Vector3 position = player.Position;
            float angle = (player.InAnyVehicle) ? player.Vehicle.Angle : player.Angle;

            Matrix rotation = Matrix.CreateRotationZ(angle);

            for (float distance = 1.0f; distance <= maxDistance; distance += 1.0f)
            {
                Vector3 offset = Vector3.Transform(Vector3.Forward * distance, rotation);
                Vector3 start = position + offset + Vector3.Up * height;
                Vector3 end = position + offset - Vector3.Up * height;

                if (RayCastLine(start, end, out Vector3 hit) == WATER_MODEL)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if there's any collision objects in front of the player.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="distance"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        static public bool IsPlayerBlocked(BasePlayer player, float distance = 1.5f, float height = 0.5f)
        {
            Vector3 position = player.Position;
            float angle = (player.InAnyVehicle) ? player.Vehicle.Angle : player.Angle;

            height = height + 1.0f;

            Matrix rotation = Matrix.CreateRotationZ(angle);
            Vector3 offset = Vector3.Transform(Vector3.Forward * distance, rotation);
            Vector3 start = position + offset + Vector3.Up * height;
            Vector3 end = position + offset - Vector3.Up * height;

            if (RayCastLine(start, end, out Vector3 hit) == WATER_MODEL)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Gets the room's height, if inside a room.
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        static public float GetRoomHeight(Vector3 start)
        {
            Vector3 end = new Vector3(start.X, start.Y, start.Z - 1000.0f);

            if (RayCastLine(start, end, out Vector3 floor) <= 0)
            {
                return float.NaN;
            }

            end = new Vector3(start.X, start.Y, start.Z + 1000.0f);

            if (RayCastLine(start, end, out Vector3 ceiling) <= 0)
            {
                return float.NaN;
            }
            return floor.DistanceTo(ceiling);
        }
        /*
        stock Float:CA_GetRoomCenter(Float:x, Float:y, Float:z, &Float:m_x, &Float:m_y)
        {
	        new Float:pt1x, Float:pt1y,
		        Float:pt2x, Float:pt2y,
		        Float:pt3x, Float:pt3y,
		        Float:tmp;

	        if(!CA_RayCastLine(x, y, z, x + 1000.0 * floatcos(0.0, degrees), y + 1000.0 * floatsin(0.0, degrees), z, pt1x, pt1y, tmp) ||
		        !CA_RayCastLine(x, y, z, x + 1000.0 * floatcos(120.0, degrees), y + 1000.0 * floatsin(120.0, degrees), z, pt2x, pt2y, tmp) ||
		        !CA_RayCastLine(x, y, z, x + 1000.0 * floatcos(-120.0, degrees), y + 1000.0 * floatsin(-120.0, degrees), z, pt3x, pt3y, tmp))
		        return -1.0;

	        new Float:yDelta_a = pt2y - pt1y,
		        Float:xDelta_a = pt2x - pt1x,
		        Float:yDelta_b = pt3y - pt2y,
		        Float:xDelta_b = pt3x - pt2x;

	        if (floatabs(xDelta_a) <= 0.000000001 && floatabs(yDelta_b) <= 0.000000001) {
		        m_x = 0.5 * (pt2x + pt3x);
		        m_y = 0.5 * (pt1y + pt2y);
		        return VectorSize(m_x - pt1x, m_y - pt1y, 0.0);
	        }

	        new Float:aSlope = yDelta_a / xDelta_a,
		        Float:bSlope = yDelta_b / xDelta_b;

	        if (floatabs(aSlope-bSlope) <= 0.000000001)
		        return -1.0;

	        m_x = (aSlope * bSlope * (pt1y - pt3y) + bSlope * (pt1x + pt2x) - aSlope * (pt2x + pt3x)) / (2.0 * (bSlope - aSlope));
	        m_y = -1.0 * (m_x - (pt1x + pt2x) / 2.0) / aSlope + (pt1y + pt2y) / 2.0;

	        return VectorSize(m_x - pt1x, m_y - pt1y, 0.0);
        }
        */
        #endregion // Functions
    }

    public class ColAndreasInternal : NativeObjectSingleton<ColAndreasInternal>
    {
        [NativeMethod(Function = "CA_Init")]
        public virtual bool Init()
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "CA_RemoveBuilding")]
        public virtual bool RemoveBuilding(int modelId, float x, float y, float z, float radius)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "CA_RayCastLine")]
        public virtual int RayCastLine(float startX, float startY, float startZ, float endX, float endY, float endZ, out float x, out float y, out float z)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "CA_RayCastLineId")]
        public virtual int RayCastLineId(float startX, float startY, float startZ, float endX, float endY, float endZ, out float x, out float y, out float z)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "CA_RayCastLineExtraID")]
        public virtual int RayCastLineExtraId(float startX, float startY, float startZ, float endX, float endY, float endZ, out float x, out float y, out float z)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(11, 11, 11, 11, 11, Function = "CA_RayCastMultiLine")]
        public virtual int RayCastMultiLine(float startX, float startY, float startZ, float endX, float endY, float endZ, out float[] x, out float[] y, out float[] z, out float[] distance, out int[] modelId, int size)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "CA_RayCastLineAngle")]
        public virtual int RayCastLineAngle(float startX, float startY, float startZ, float endX, float endY, float endZ, out float x, out float y, out float z, out float rx, out float ry, out float rz)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "CA_RayCastReflectionVector")]
        public virtual int RayCastReflectionVector(float startX, float startY, float startZ, float endX, float endY, float endZ, out float x, out float y, out float z, out float nx, out float ny, out float nz)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "CA_RayCastLineNormal")]
        public virtual int RayCastLineNormal(float startX, float startY, float startZ, float endX, float endY, float endZ, out float x, out float y, out float z, out float nx, out float ny, out float nz)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "CA_ContactTest")]
        public virtual int ContactTest(int modelId, float x, float y, float z, float rx, float ry, float rz)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "CA_EulerToQuat")]
        public virtual int EulerToQuat(float rx, float ry, float rz, out float x, out float y, out float z, out float w)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "CA_QuatToEuler")]
        public virtual int QuatToEuler(float x, float y, float z, float w, out float rx, out float ry, out float rz)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "CA_GetModelBoundingSphere")]
        public virtual int GetModelBoundingSphere(int modelId, out float offsetX, out float offsetY, out float offsetZ, out float radius)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "CA_GetModelBoundingBox")]
        public virtual int GetModelBoundingBox(int modelId, out float minX, out float minY, out float minZ, out float maxX, out float maxY, out float maxZ)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "CA_RayCastLineEx")]
        public virtual int RayCastLineEx(float startX, float startY, float startZ, float endX, float endY, float endZ, out float x, out float y, out float z, out float rx, out float ry, out float rz, out float rw, out float cx, out float cy, out float cz)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "CA_RayCastLineAngleEx")]
        public virtual int RayCastLineAngleEx(float startX, float startY, float startZ, float endX, float endY, float endZ, out float x, out float y, out float z, out float rx, out float ry, out float rz, out float ocx, out float ocy, out float ocz, out float orx, out float ory, out float orz)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "CA_CreateObject")]
        public virtual int CreateObject(int modelId, float x, float y, float z, float rx, float ry, float rz, bool index = false)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "CA_DestroyObject")]
        public virtual int DestroyObject(int collisionId)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "CA_SetObjectPos")]
        public virtual int SetObjectPos(int collisionId, float x, float y, float z)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "CA_SetObjectRot")]
        public virtual int SetObjectRot(int collisionId, float rx, float ry, float rz)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "CA_SetObjectExtraID")]
        public virtual int SetObjectExtraID(int collisionId, int data, int value)
        {
            throw new NativeNotImplementedException();
        }

        [NativeMethod(Function = "CA_GetObjectExtraID")]
        public virtual int GetObjectExtraID(int collisionId, int data)
        {
            throw new NativeNotImplementedException();
        }
    }
}