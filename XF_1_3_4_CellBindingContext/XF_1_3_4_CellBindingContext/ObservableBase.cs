﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XF_1_3_4_CellBindingContext
{
	public abstract class ObservableBase : INotifyPropertyChanged, INotifyPropertyChanging
	{

		#region Constructors

		/// <summary>
		/// Default constructor.
		/// </summary>
		protected ObservableBase( )
		{
		}

		#endregion

		#region Properties

		public bool Initialized { get; set; }

		private bool _isBusy;
		public bool IsBusy
		{
			get { return _isBusy;  }
			set
			{
				SetField(ref _isBusy, value);
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Sets the value of the <paramref name="field"/> to the new value and raises the appropriate
		/// property change notifications.
		/// </summary>
		/// <typeparam name="T">The type of the field to be set.</typeparam>
		/// <param name="field">The field to set, passed by reference.</param>
		/// <param name="newValue">The new value to set on the field.</param>
		/// <param name="propertyName">The name of the property that will be communicated in the property change event.</param>
		/// <returns>True if the field was changed, false if the new value was the same as the old value.</returns>
		protected bool SetField<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(field, newValue))
			{
				return false;
			}

			OnPropertyChanging(propertyName);

			field = newValue;

			OnPropertyChanged(propertyName);

			return true;
		}

		/// <summary>
		/// Raises the <see cref="PropertyChanging"/> event.
		/// </summary>
		/// <param name="propertyName">The name of the property that is changing.</param>
		protected virtual void OnPropertyChanging([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanging;
			if (handler != null)
			{
				handler(this, new PropertyChangingEventArgs(propertyName));
			}
		}

		/// <summary>
		/// Raises the <see cref="PropertyChanged"/> event.
		/// </summary>
		/// <param name="propertyName">The name of the property that changed.</param>
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		#endregion

		#region Events

		/// <summary>
		/// Event that is raised before the property is changed.
		/// </summary>
		public event PropertyChangingEventHandler PropertyChanging;

		/// <summary>
		/// Event that is raised after a property is changed.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		#endregion
	}
}

