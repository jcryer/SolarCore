using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarForms.Components
{
    public interface ICamera
    {
        Matrix4 LookAtMatrix { get; }
        void Update(double time, double delta);
    }

    public class StaticCamera : ICamera
    {
        public Matrix4 LookAtMatrix { get; }
        public StaticCamera()
        {
            Vector3 position;
            position.X = 0;
            position.Y = 0;
            position.Z = 0;
            LookAtMatrix = Matrix4.LookAt(position, -Vector3.UnitZ, Vector3.UnitY);
        }
        public StaticCamera(Vector3 position, Vector3 target)
        {
            LookAtMatrix = Matrix4.LookAt(position, target, Vector3.UnitY);
        }
        public void Update(double time, double delta)
        { }
    }

    public class FirstPersonCamera : ICamera
    {
        public Matrix4 LookAtMatrix { get; private set; }
        private readonly SolarObject _target;
        private readonly Vector3 _offset;

        public FirstPersonCamera(SolarObject target)
            : this(target, Vector3.Zero)
        { }
        public FirstPersonCamera(SolarObject target, Vector3 offset)
        {
            _target = target;
            _offset = offset;
        }

        public void Update(double time, double delta)
        {
            LookAtMatrix = Matrix4.LookAt(
                new Vector3(_target.Position) + _offset,
                new Vector3(_target.Position + _target.Velocity) + _offset,
                Vector3.UnitY);
        }
    }

    public class ThirdPersonCamera : ICamera
    {
        public Matrix4 LookAtMatrix { get; private set; }
        private readonly SolarObject _target;
        private readonly Vector3 _offset;

        public ThirdPersonCamera(SolarObject target)
            : this(target, Vector3.Zero)
        { }
        public ThirdPersonCamera(SolarObject target, Vector3 offset)
        {
            _target = target;
            _offset = offset;
        }

        public void Update(double time, double delta)
        {
            LookAtMatrix = Matrix4.LookAt(
                new Vector3(_target.Position) + (_offset * new Vector3(_target.Velocity.Normalized())),
                new Vector3(_target.Position),
                Vector3.UnitY);
        }
    }
}
