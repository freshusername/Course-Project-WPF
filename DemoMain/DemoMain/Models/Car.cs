using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMain.Models
{
    public class Car : INotifyPropertyChanged
    {
        public Car(string carName, string carModel, string carTransmission, string carGazType, float carEngineLitres, string carTypeOfCar, float carPrice, string carImgPath, int carDiscount)
        {
            this.carName = carName;
            this.carModel = carModel;
            this.carTransmission = carTransmission;
            this.carGazType = carGazType;
            this.carEngineLitres = carEngineLitres;
            this.carTypeOfCar = carTypeOfCar;
            this.carPrice = carPrice;
            this.carImgPath = carImgPath;
            this.carDiscount = carDiscount;
        }

        private string _carName;
        /// <summary>
        /// Gets or sets the Car's name.
        /// </summary>
        public String carName
        {
            get
            {   return _carName; }
            set
            {
                _carName = value;
                OnPropertyChanged("carName");
            }
        }

        /// <summary>
        /// Gets or sets the Car's Model.
        /// </summary>
        private string _carModel;
        public String carModel
        {
            get { return _carModel; }
            set
            {
                _carModel = value;
                OnPropertyChanged("carModel");
            }
        }
        /// <summary>
        /// Gets or sets the Car's Transmission.
        /// </summary>
        private string _carTransmission;
        public String carTransmission
        {
            get { return _carTransmission; }
            set
            {
                _carTransmission = value;
                OnPropertyChanged("carTransmission");
            }
        }
        /// <summary>
        /// Gets or sets the Car's Gaz Type.
        /// </summary>
        private string _carGazType;
        public String carGazType
        {
            get { return _carGazType; }
            set
            {
                _carTransmission = value;
                OnPropertyChanged("carGazType");
            }
        }
        /// <summary>
        /// Gets or sets the Car's Engine Litres.
        /// </summary>
        private float _carEngineLitres;
        public float carEngineLitres
        {
            get { return _carEngineLitres; }
            set
            {
                _carEngineLitres = value;
                OnPropertyChanged("carEngineLitres");
            }
        }
        /// <summary>
        /// Gets or sets the Car's Type.
        /// </summary>
        private string _carTypeOfCar;
        public String carTypeOfCar
        {
            get { return _carTypeOfCar; }
            set
            {
                _carTypeOfCar = value;
                OnPropertyChanged("carTypeOfCar");
            }
        }
        /// <summary>
        /// Gets or sets the Car's Price.
        /// </summary>
        private float _carPrice;
        public float carPrice
        {
            get { return _carPrice; }
            set
            {
                _carPrice = value;
                OnPropertyChanged("carPrice");
            }
        }
        /// <summary>
        /// Gets or sets the Car's Photos.
        /// </summary>
        private string _carImgPath;
        public String carImgPath
        {
            get { return _carImgPath; }
            set
            {
                _carImgPath = value;
                OnPropertyChanged("carImgPath");
            }
        }
        /// <summary>
        /// Gets or sets the Car's Discount.
        /// </summary>
        private int _carDiscount;
        public int carDiscount
        {
            get { return _carDiscount; }
            set
            {
                _carDiscount = value;
                OnPropertyChanged("carDiscount");
            }
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
