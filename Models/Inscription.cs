//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Inscription
    {
        public int ID_inscription { get; set; }
        public byte[] Curriculum_vitae { get; set; }
        public byte[] Diplome { get; set; }
        public Nullable<System.DateTime> Date_dépot { get; set; }
        public string Nom { get; set; }
        public string Prénom { get; set; }
        public string Numéro_CIN { get; set; }
        public string Téléphone { get; set; }
        public Nullable<System.DateTime> Date_naissance { get; set; }
        public string Lieu_naissance { get; set; }
        public string code_postal { get; set; }
        public string Sexe { get; set; }
        public string Ville { get; set; }
        public Nullable<int> ID_profil { get; set; }
        public Nullable<int> ID_gestionnaire { get; set; }
        public Nullable<int> ID_concours { get; set; }
        public string Mot_de_passe { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Ce champ est requis.")]
        public string Statut { get; set; }
    
        public virtual Concour Concour { get; set; }
        public virtual Gestionnaire Gestionnaire { get; set; }
        public virtual Profil Profil { get; set; }
    }
}