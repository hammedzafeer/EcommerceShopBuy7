// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//let category_clicked = document.getElementById("category_clicked");
//category_clicked.addEventListener("click", () => {
//    let category_drop = document.getElementsByClassName("categort_dropdown")[0];
//    category_drop.classList.toggle("Active");
//    console.log("clicked")
//})
$(document).ready(function () {
    $("#category_clicked").click(function () {
        $("#cate_active").slideToggle("slow");
    });
});

//var swiper = new Swiper(".box-swiper", {
//    slidesPerView: 3,
//    centerSlide: true,
//    loop: true,
//    autoplay: true,
//    fade: true,
//    // speed: 3,
//    grabCursor: 'true',
//    allowTouchMove: true,
//     pagination: {
//       el: ".swiper-pagination",
//       clickable: true,
//       dynamicBullets: true,
//     },
//     keyboard: {
//       enabled: true,
//     },
//    breakpoints: {
//        0: {
//            slidesPerView: 1,
//        },
//        360: {
//            slidesPerView: 1,
//        },
//        768: {
//            slidesPerView: 2,
//        },
//        992: {
//            slidesPerView: 3,
//        },
//    },

//    navigation: {
//        nextEl: ".swiper-button-next",
//        prevEl: ".swiper-button-prev",
//    },

//});

$('.IndexcategoryItems .owl-carousel').owlCarousel({
    loop: true,
    autoplay: true,
    dots: true,
    nav: false,
    responsiveClass: true,
    paginationSpeed: true,
    autoplayHoverPause: true,
    margin: 12,
    responsive: {
        0: {
            items: 1
        },
        480: {
            items: 2
        },
        991: {
            items: 3
        }
    }
})

$('.two-card .owl-carousel').owlCarousel({
    loop: false,
    autoplay: false,
    dots: false,
    nav: false,
    responsiveClass: true,
    paginationSpeed: true,
    autoplayHoverPause: true,

    margin: 12,

    responsive: {
        0: {
            items: 1
        },
        768: {
            items: 1
        },
        991: {
            items: 2
        }
    }
})
$('.one-card.owl-carousel').owlCarousel({
    loop: false,
    autoplay: false,
    dots: false,
    nav: true,

    responsiveClass: true,
    paginationSpeed: true,
    autoplayHoverPause: true,
    navText: ["<i class='fa fa-chevron-left'></i> Previous Deal", "Next Deal <i class='fa fa-chevron-right'></i>"],
    margin: 12,

    responsive: {
        0: {
            items: 1
        },
        768: {
            items: 1
        },
        991: {
            items: 1
        }
    }
})
$('.realted_deal .owl-carousel').owlCarousel({
    loop: false,
    autoplay: false,
    dots: false,
    nav: true,
    responsiveClass: true,
    paginationSpeed: true,
    autoplayHoverPause: true,

    margin: 7,

    responsive: {
        0: {
            items: 2
        },
        480: {
            items: 3
        },
        768: {
            items: 3
        },
        991: {
            items: 3
        }
    }
})


$('.BestSaller .owl-carousel').owlCarousel({
    loop: true,
    autoplay: true,
    dots: true,
    nav: false,
    responsiveClass: true,
    paginationSpeed: true,
    autoplayHoverPause: true,

    margin: 1,
    responsive: {
        0: {
            items: 1
        },
        768: {
            items: 1
        },
        991: {
            items: 2
        }
    }
})
$('.latest .owl-carousel').owlCarousel({
    loop: true,
    autoplay: false,
    dots: false,
    nav: true,
    responsiveClass: true,
    paginationSpeed: true,
    autoplayHoverPause: true,

    margin: 7,
    responsive: {
        0: {
            items: 1
        },
        768: {
            items: 2
        },
        991: {
            items: 1
        }
    }
})


$('.oneShow .owl-carousel').owlCarousel({
    loop: true,
    autoplay: true,
    dots: true,
    nav: false,
    responsiveClass: true,
    paginationSpeed: true,
    autoplayHoverPause: true,

    margin: 1,
    responsive: {
        0: {
            items: 1
        },
        768: {
            items: 1
        },
        991: {
            items: 2
        }
    }
})

$('.brands .owl-carousel').owlCarousel({
    loop: true,
    autoplay: true,
    dots: false,
    nav: false,
    responsiveClass: true,
    paginationSpeed: true,
    autoplayHoverPause: true,
    autoplayTimeout: 1000,

    margin: 7,

    responsive: {
        0: {
            items: 2
        },
        480: {
            items: 3
        },
        768: {
            items: 5
        },
        991: {
            items: 7
        }
    }
})